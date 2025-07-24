using FesteroApp.Domain.Interfaces.Users;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.UpdateUser;

public class UpdateUserHandler(IUserRepository repository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<UpdateUserCommand>
{
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(UpdateUserCommand command)
    {
        var user = await repository.GetAsyncById(command.Id);
        Throw.IsNull(user, "User", "Usuário nao encontrado.");
            
        await repository.UpdateAsync(user!);
    }
}