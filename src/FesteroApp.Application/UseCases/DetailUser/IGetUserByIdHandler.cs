namespace FesteroApp.Application.UseCases.DetailUser
{
    public interface IGetUserByIdHandler
    {
        Task<UserDetailQueryResult?> HandleAsync(Guid id);
    }
}