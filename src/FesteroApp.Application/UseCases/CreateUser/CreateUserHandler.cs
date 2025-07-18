﻿using FesteroApp.Domain.Entities.Users;
using FesteroApp.Domain.Interfaces;

namespace FesteroApp.Application.UseCases.CreateUser
{
    public class CreateUserHandler(IRepository<User> userRepository, IUnitOfWork unitOfWork) : ICreateUserHandler
    {
        private readonly IRepository<User> _repository = userRepository;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Guid> HandleAsync(CreateUserCommand dto)
        {
            var user = new User(Guid.NewGuid(), dto.Name, dto.Email, dto.Password);

            await _repository.AddAndCommitAsync(user);

            return user.Id;
        }
    }
}