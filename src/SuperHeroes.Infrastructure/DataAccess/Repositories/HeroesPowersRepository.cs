using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories.HeroesPowers;

namespace SuperHeroes.Infrastructure.DataAccess.Repositories
{
    public class HeroesPowersRepository : IHeroesPowersWriteOnlyRepository
    {
        private readonly SuperHeroesDbContext _dbContext;

        public HeroesPowersRepository(SuperHeroesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(List<HeroPower> heroPowers)
        {
            await _dbContext.AddRangeAsync(heroPowers);
        }

        public async Task DeleteHeroPowers(int superHeroId)
        {
            var heroPowers = await _dbContext.HeroesPowers.Where(hp => hp.HeroId == superHeroId).ToListAsync();
            _dbContext.HeroesPowers.RemoveRange(heroPowers);
        }
    }
}
