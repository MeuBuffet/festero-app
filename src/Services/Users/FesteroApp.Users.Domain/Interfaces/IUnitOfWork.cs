namespace FesteroApp.Users.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}