namespace FesteroApp.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}