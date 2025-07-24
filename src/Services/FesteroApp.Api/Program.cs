using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;
using FesteroApp.Api.Authorization.Handlers;
using FesteroApp.Api.Authorization.Requirements;
using FesteroApp.Api.Helpers;
using FesteroApp.Api.Middlewares;
using FesteroApp.Application;
using FesteroApp.Domain;
using FesteroApp.Infrastructure;
using FesteroApp.SharedKernel;
using Microsoft.AspNetCore.Authorization;
using SrShut.Common.AppSettings;
using SrShut.Cqrs.Traces;
using SrShut.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MassTransit.Configuration;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.AddServerHeader = false;
    serverOptions.Limits.MaxRequestBodySize = long.MaxValue;
});

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;

var culture = CultureInfo.CurrentCulture = new CultureInfo("pt-BR");
CultureInfo.CurrentUICulture = culture;
CultureInfo.DefaultThreadCurrentCulture = culture;
CultureInfo.DefaultThreadCurrentUICulture = culture;

// 🧱 Add DI
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<ITenantContext, TenantContext>();
builder.Services.AddScoped<IAuthorizationHandler, RoleInTenantRequirementHandler>();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("TenantAdmin", policy =>
        policy.Requirements.Add(new RoleInTenantRequirement("OWNER", "ADMIN")));
    
    options.AddPolicy("TenantViewer", policy =>
        policy.Requirements.Add(new RoleInTenantRequirement("VIEWER", "COLLABORATOR", "ADMIN", "OWNER")));
});

services.AddControllers(a => { a.Filters.Add(typeof(UnitOfWorkAttribute)); })
    .AddJsonOptions(a => {
        a.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        a.JsonSerializerOptions.PropertyNameCaseInsensitive = true; 
        a.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase; 
    });
   

// LogManager.Configuration = new NLogLoggingConfiguration(builder.Configuration.GetSection("NLog"));
// builder.Logging.ClearProviders();
// builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
// builder.Logging.AddNLog(configuration);

services.AddCors(option => option.AddPolicy("FesteroAppPolicy", policyBuilder =>
{
    policyBuilder.WithExposedHeaders("Content-Disposition")
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FesteroApp API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header.  
                        Informe assim: Bearer **seu_token_aqui**",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "Bearer",
                Name = "Bearer",
                In = ParameterLocation.Header
            },
            new List<string>()
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

    c.MapType<DateTime>(() => new OpenApiSchema { Type = "string", Format = "date" });
    c.OrderActionsBy(apiDesc => apiDesc.RelativePath);
});

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidIssuer = "FesteroAuth",
        ValidAudience = "FesteroApiClients",
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(configuration["Security:Secret"]!))
    };

    options.Events = new JwtBearerEvents
    {
        OnForbidden = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            context.Response.ContentType = "application/json";

            var result = JsonSerializer.Serialize(new
            {
                success = false,
                message = "Voce nao tem permissão para acessar este recurso."
            });

            return context.Response.WriteAsync(result);
        }
    };
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }
// else
// {
//     app.UseExceptionHandler("/Error");
//     app.UseHsts();
// }

app.UseTrace();
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("FesteroAppPolicy");
app.UseAuthentication();
app.UseMiddleware<TenantMiddleware>();
app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();
app.UseSwagger(c =>
{
    var apiUrl = configuration.AppSettings("ApiUrl")!;

    if (!string.IsNullOrEmpty(apiUrl))
    {
        c.PreSerializeFilters.Add((swagger, _) =>
        {
            swagger.Servers = new List<OpenApiServer>
            {
                new OpenApiServer { Url = apiUrl }
            };
        });
    }
});

app.UseSwaggerUI(options => { options.SwaggerEndpoint("./v1/swagger.json", "FesteroApp - API"); });

app.Run();