using System.Reflection;
using FesteroApp.SharedKernel;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FesteroApp.Api.Filters;

public class EmptyFieldsSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsClass || context.Type == typeof(string))
            return;

        var example = new OpenApiObject();

        foreach (var prop in context.Type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            if (prop.PropertyType == typeof(string))
                example.Add(prop.Name.ToCamelCase(), new OpenApiString(""));
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
                example.Add(prop.Name.ToCamelCase(), new OpenApiInteger(0));
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
                example.Add(prop.Name.ToCamelCase(), new OpenApiBoolean(false));
        }

        schema.Example = example;
    }
}