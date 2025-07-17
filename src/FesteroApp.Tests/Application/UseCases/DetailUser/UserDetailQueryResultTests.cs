using FesteroApp.Application.UseCases.DetailUser;

namespace FesteroApp.Tests.Application.UseCases.DetailUser
{
    [TestFixture]
    public class UserDetailQueryResultTests
    {
        [Test]
        public void Constructor_AssignsPropertiesCorrectly()
        {
            var id = Guid.NewGuid();
            var name = "Maria";
            var email = "maria@email.com";
            var dto = new UserDetailQueryResult(id, name, email);

            Assert.Multiple(() =>
            {
                Assert.That(dto.Id, Is.EqualTo(id));
                Assert.That(dto.Name, Is.EqualTo(name));
                Assert.That(dto.Email, Is.EqualTo(email));
            });
        }

        [Test]
        public void Constructor_AllowsNullValues()
        {
            var dto = new UserDetailQueryResult(null, null, null);

            Assert.Multiple(() =>
            {
                Assert.That(dto.Id, Is.Null);
                Assert.That(dto.Name, Is.Null);
                Assert.That(dto.Email, Is.Null);
            });
        }

        [Test]
        public void Properties_CanBeModified()
        {
            var dto = new UserDetailQueryResult(Guid.Empty, "", "");

            var newId = Guid.NewGuid();
            dto.Id = newId;
            dto.Name = "João";
            dto.Email = "joao@email.com";

            Assert.Multiple(() =>
            {
                Assert.That(dto.Id, Is.EqualTo(newId));
                Assert.That(dto.Name, Is.EqualTo("João"));
                Assert.That(dto.Email, Is.EqualTo("joao@email.com"));
            });
        }
    }
}
