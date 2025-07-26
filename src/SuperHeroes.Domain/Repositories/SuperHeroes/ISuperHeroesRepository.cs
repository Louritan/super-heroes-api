using SuperHeroes.Domain.DTOs;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperHeroes
{
    public interface ISuperHeroesRepository
    {
        Task Add(SuperHero superHero);
        Task<SuperHeroListDTO> GetAll();
    }
}
