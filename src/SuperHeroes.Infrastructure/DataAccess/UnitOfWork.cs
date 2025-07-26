using SuperHeroes.Domain.Repositories;

namespace SuperHeroes.Infrastructure.DataAccess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly SuperHeroesDbContext _dbContext;

        public UnitOfWork(SuperHeroesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
