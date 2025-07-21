// using FesteroApp.Users.Domain.Interfaces;
// using FesteroApp.Users.Infrastructure;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
//
// namespace FesteroApp.Tests.Infrastructure
// {
//     [TestFixture]
//     public class DependencyInjectionInfrastructureTests
//     {
//         [Test]
//         public void AddInfrastructure_Registers_Database_AndRepositories()
//         {
//             var configData = new Dictionary<string, string>
//             {
//                 { "ConnectionStrings:DefaultConnection", "Server=localhost;Database=FakeDb;Trusted_Connection=True;" }
//             };
//
//             var configuration = new ConfigurationBuilder()
//                 .AddInMemoryCollection(configData!)
//                 .Build();
//
//             var services = new ServiceCollection();
//             services.AddInfrastructure(configuration);
//
//             var provider = services.BuildServiceProvider();
//             var dbContext = provider.GetService<ApplicationDbContext>();
//             var repo = provider.GetService<IRepository<object>>();
//             var uow = provider.GetService<IUnitOfWork>();
//
//             Assert.That(dbContext, Is.Not.Null);
//             Assert.Multiple(() =>
//             {
//                 Assert.That(dbContext, Is.InstanceOf<DbContext>());
//                 Assert.That(repo, Is.Not.Null);
//             });
//             Assert.Multiple(() =>
//             {
//                 Assert.That(repo, Is.InstanceOf<Repository<object>>());
//                 Assert.That(uow, Is.Not.Null);
//             });
//             Assert.That(uow, Is.InstanceOf<UnitOfWork>());
//         }
//     }
// }
