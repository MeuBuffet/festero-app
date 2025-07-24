//using FesteroApp.Domain.Entities.Users;

//namespace FesteroApp.Tests.Domain.Entities.Users;

//[TestFixture]
//public class UserTests
//{
//    [Test]
//    public void Constructor_ShouldInitializePropertiesCorrectly()
//    {
//        var id = Guid.NewGuid();
//        var name = "Maria Clara";
//        var email = "maria@email.com";
//        var password = "Senha123!";
//        var user = new User(id, name, email, password);

//        Assert.Multiple(() =>
//        {
//            Assert.That(user.Id, Is.EqualTo(id));
//            Assert.That(user.Name, Is.EqualTo(name));
//            Assert.That(user.Email, Is.EqualTo(email));
//            Assert.That(user.Password, Is.EqualTo(password));
//            Assert.That(user.CreatedOn, Is.Not.Null);
//            Assert.That(user.UpdatedOn, Is.Not.Null);
//            Assert.That(user.DeletedOn, Is.Null);
//        });
//    }

//    [Test]
//    public void Delete_ShouldSetDeletedOnToNow()
//    {
//        var user = new User(Guid.NewGuid(), "Carlos", "carlos@email.com", "12345678");

//        user.Delete();

//        Assert.That(user.DeletedOn, Is.Not.Null);
//        Assert.That(user.DeletedOn.Value, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromSeconds(2)));
//    }
//}