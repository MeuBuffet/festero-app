using FesteroApp.Api.Filters;
using FesteroApp.Api.Middleware;
using FesteroApp.Application;
using FesteroApp.Domain;
using FesteroApp.Infrastructure;
using FesteroApp.Migrations.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// 🔧 Executa migrations
MigrationRunnerService.Execute(builder.Configuration.GetConnectionString("DefaultConnection")!);

// 🔐 Configura autenticação JWT
var key = Encoding.ASCII.GetBytes(builder.Configuration["Security:Key"]!);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false; // em produção, mude para true
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Security:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Security:Audience"],
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});

// 🧱 Add DI
builder.Services.AddApplication();
builder.Services.AddDomain();
builder.Services.AddInfrastructure(builder.Configuration);

// 🧩 Filters e ModelState
builder.Services.AddControllers(options =>
{
    options.Filters.Add<HttpExceptionFilter>();
    options.Filters.Add<FluentValidationFilter>();
});

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

// 🌐 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<EmptyFieldsSchemaFilter>();
    options.SupportNonNullableReferenceTypes();

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "FesteroApp API",
        Version = "v1"
    });

    // 🔐 Definição de esquema JWT
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Insira o token JWT no formato: Bearer {seu_token}",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    options.AddSecurityDefinition("Bearer", securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

var app = builder.Build();

// 🌍 Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication(); // 🛡️ antes do UseAuthorization
app.UseAuthorization();

app.MapControllers();

app.Run();