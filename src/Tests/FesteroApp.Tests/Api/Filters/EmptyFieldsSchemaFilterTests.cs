using FesteroApp.Users.Api.Filters;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace FesteroApp.Tests.Api.Filters
{
    public class DummyTestModel
    {
        public string? Name { get; set; }
        public int? Age { get; set; }
        public bool? Active { get; set; }
        public DateTime? CreatedOn { get; set; }
    }

    public class DummySchemaFilterContext(Type type) : SchemaFilterContext(type, null!, null!)
    {
    }

    [TestFixture]
    public class EmptyFieldsSchemaFilterTests
    {
        [Test]
        public void Apply_ShouldSetExampleValues_ForSupportedTypes()
        {
            // Arrange
            var schema = new OpenApiSchema();
            var context = new DummySchemaFilterContext(typeof(DummyTestModel));
            var filter = new EmptyFieldsSchemaFilter();

            // Act
            filter.Apply(schema, context);

            Assert.NotNull(schema.Example);

            var example = schema.Example as OpenApiObject;

            Assert.Multiple(() =>
            {
                Assert.That(example, Is.Not.Null);
                Assert.That(example!.ContainsKey("name"));
                Assert.That(((OpenApiString)example["name"]).Value, Is.EqualTo(""));
                Assert.That(example.ContainsKey("age"));
                Assert.That(((OpenApiInteger)example["age"]).Value, Is.EqualTo(0));
                Assert.That(example.ContainsKey("active"));
                Assert.That(((OpenApiBoolean)example["active"]).Value, Is.EqualTo(false));
                Assert.False(example.ContainsKey("createdOn"));
            });
        }
    }
}
