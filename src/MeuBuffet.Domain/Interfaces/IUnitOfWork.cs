namespace MeuBuffet.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}