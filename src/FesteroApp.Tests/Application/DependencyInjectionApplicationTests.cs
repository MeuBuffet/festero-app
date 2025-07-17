using FesteroApp.Application;
using FesteroApp.Application.UseCases.CreateUser;
using FesteroApp.Application.UseCases.DetailUser;
using FesteroApp.Application.UseCases.LoginUser;
using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces;
using FesteroApp.Domain.Security;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Linq.Expressions;

namespace FesteroApp.Tests.Application
{
    public class FakeUserRepository : IRepository<User>
    {
        public Task<User?> GetByIdAsync(Guid id) => Task.FromResult<User?>(null);

        public Task<IEnumerable<User>> GetAllAsync() => Task.FromResult<IEnumerable<User>>(new List<User>());

        public Task AddAsync(User entity) => Task.CompletedTask;

        public Task AddAndCommitAsync(User entity) => Task.CompletedTask;

        public void Update(User entity) { }

        public Task UpdateAndCommitAsync(User entity) => Task.CompletedTask;

        public void Remove(User entity) { }

        public Task RemoveAndCommitAsync(User entity) => Task.CompletedTask;

        public Task<T?> GetByAsync<T>(Expression<Func<T, bool>> predicate) where T : class
            => Task.FromResult<T?>(null);
    }

    public class FakeUnitOfWork : IUnitOfWork
    {
        public Task CommitAsync() => Task.CompletedTask;
        public void Dispose() { }
    }

    public class FakeTokenGenerator : ITokenGenerator
    {
        public string Generate(User user) => "fake-jwt-token";
    }

    [TestFixture]
    public class DependencyInjectionApplicationTests
    {
        [Test]
        public void AddApplication_Registers_Handlers_AndValidators()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IRepository<User>, FakeUserRepository>();
            services.AddSingleton<IUnitOfWork, FakeUnitOfWork>();
            services.AddSingleton<ITokenGenerator, FakeTokenGenerator>();
            services.AddApplication();
            var provider = services.BuildServiceProvider();

            Assert.Multiple(() =>
            {
                Assert.That(provider.GetService<ICreateUserHandler>(), Is.Not.Null);
                Assert.That(provider.GetService<IGetUserByIdHandler>(), Is.Not.Null);
                Assert.That(provider.GetService<ILoginUserHandler>(), Is.Not.Null   );
                Assert.That(provider.GetService<IValidator<CreateUserCommand>>(), Is.Not.Null);
            });
        }
    }
}
