using FesteroApp.Domain.Interfaces.Users;
using SrShut.Common;
using SrShut.Cqrs.Commands;
using SrShut.Data;

namespace FesteroApp.Application.UseCases.Users.DeleteUser;

public class DeleteUserHandler(IUserRepository repository, IUnitOfWorkFactory unitOfWork) :
    ICommandHandler<DeleteUserCommand>
{
    private readonly IUnitOfWorkFactory _unitOfWork = unitOfWork;

    public async Task HandleAsync(DeleteUserCommand command)
    {
        var user = await repository.GetAsyncById(command.Id);
        Throw.IsNull(user, "User.Delete", "Usuário nao encontrado.");
            
        user.Delete();
        
        await repository.UpdateAsync(user!);
    }
}