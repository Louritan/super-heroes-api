using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperHeroes
{
    public interface ISuperHeroesUpdateOnlyRepository
    {
        Task<SuperHero?> GetById(int id);
        void Update(SuperHero superHero);
    }
}
