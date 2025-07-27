using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories.SuperPowers;

namespace SuperHeroes.Infrastructure.DataAccess.Repositories
{
    public class SuperPowersRepository : ISuperPowersReadOnlyRepository, ISuperPowersWriteOnlyRepository
    {
        private readonly SuperHeroesDbContext _dbContext;

        public SuperPowersRepository(SuperHeroesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(SuperPower superPower)
        {
            await _dbContext.SuperPowers.AddAsync(superPower);
        }

        public async Task<bool> Exists(List<int> superPowerIds)
        {
            var existingCount = await _dbContext.SuperPowers
                .AsNoTracking()
                .CountAsync(sp => superPowerIds.Contains(sp.Id));

            return existingCount == superPowerIds.Count;
        }

        public async Task<List<SuperPower>> GetAll()
        {
            return await _dbContext.SuperPowers.AsNoTracking().ToListAsync();
        }

        public Task<int> GetCount()
        {
            return _dbContext.SuperPowers.AsNoTracking().CountAsync();
        }
    }
}
