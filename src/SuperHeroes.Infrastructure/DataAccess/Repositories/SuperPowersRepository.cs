using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories.SuperPowers;

namespace SuperHeroes.Infrastructure.DataAccess.Repositories
{
    public class SuperPowersRepository : ISuperPowersRepository
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

        public async Task<List<int>> GetExistingIds(List<int> superPowerIds)
        {
            return await _dbContext.SuperPowers
                .Where(sp => superPowerIds.Contains(sp.Id))
                .Select(sp => sp.Id)
                .ToListAsync();
        }
    }
}
