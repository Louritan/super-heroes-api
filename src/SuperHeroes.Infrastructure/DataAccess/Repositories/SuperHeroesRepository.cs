using Microsoft.EntityFrameworkCore;
using SuperHeroes.Domain.DTOs;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories.SuperHeroes;

namespace SuperHeroes.Infrastructure.DataAccess.Repositories
{
    internal class SuperHeroesRepository : ISuperHeroesReadOnlyRepository, ISuperHeroesWriteOnlyRepository, ISuperHeroesUpdateOnlyRepository
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

        public async Task<bool> Delete(int id)
        {
            var result = await _dbContext.SuperHeroes.FirstOrDefaultAsync(sh => sh.Id == id);

            if (result is null)
                return false;

            _dbContext.SuperHeroes.Remove(result);
            return true;
        }

        public async Task<SuperHeroListDTO> GetAll()
        {
            var superHeroes = await _dbContext.SuperHeroes
                .AsNoTracking()
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
                SuperHeroes = superHeroes
            };
        }

        async Task<SuperHeroDTO?> ISuperHeroesReadOnlyRepository.GetById(int id)
        {
            var superHero = await _dbContext.SuperHeroes
                .AsNoTracking()
                .Where(sh => sh.Id == id)
                .Select(sh => new SuperHeroDTO
                {
                    Id = sh.Id,
                    Name = sh.Name,
                    HeroName = sh.HeroName,
                    BirthDate = sh.BirthDate,
                    Height = sh.Height,
                    Weight = sh.Weight,
                    SuperPowers = sh.HeroesPowers.Select(hp => new SuperPowerDTO
                    {
                        Id = hp.SuperPower.Id,
                        Name = hp.SuperPower.Name,
                        Description = hp.SuperPower.Description
                    }).ToList(),
                }).FirstOrDefaultAsync();

            return superHero;
        }

        public async Task<bool> HeroNameExists(string heroName, int? excludeId)
        {
            return await _dbContext.SuperHeroes
                .AsNoTracking()
                .AnyAsync(sh => sh.HeroName == heroName && (!excludeId.HasValue || sh.Id != excludeId.Value));
        }

        public void Update(SuperHero superHero)
        {
            _dbContext.SuperHeroes.Update(superHero);
        }

        async Task<SuperHero?> ISuperHeroesUpdateOnlyRepository.GetById(int id)
        {
            return await _dbContext.SuperHeroes.FirstOrDefaultAsync(sh => sh.Id == id);
        }
    }
}
