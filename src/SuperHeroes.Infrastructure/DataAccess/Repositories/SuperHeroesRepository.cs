using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.DTOs;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories.SuperHeroes;

namespace SuperHeroes.Infrastructure.DataAccess.Repositories
{
    internal class SuperHeroesRepository : ISuperHeroesRepository
    {
        private readonly SuperHeroesDbContext _dbContext;

        public SuperHeroesRepository(SuperHeroesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(SuperHero superHero)
        {
            await _dbContext.SuperHeroes.AddAsync(superHero);
        }

        public async Task<SuperHeroListDTO> GetAll()
        {
            var heroes = await _dbContext.SuperHeroes
                .Include(x => x.HeroesPowers)
                .ThenInclude(p => p.SuperPower)
                .Select(x => new SuperHeroShortDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    HeroName = x.HeroName,
                    SuperPowers = x.HeroesPowers.Select(p => new SuperPowerShortDTO
                    {
                        Id = p.SuperPower.Id,
                        Name = p.SuperPower.Name
                    }).ToList(),
                }).ToListAsync();

            return new SuperHeroListDTO
            {
                SuperHeroes = heroes
            };
        }
    }
}
