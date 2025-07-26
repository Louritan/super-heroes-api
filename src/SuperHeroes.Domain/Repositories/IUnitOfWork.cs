namespace SuperHeroes.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
