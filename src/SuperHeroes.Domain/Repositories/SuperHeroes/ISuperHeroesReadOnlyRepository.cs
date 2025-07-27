using SuperHeroes.Domain.DTOs;

namespace SuperHeroes.Domain.Repositories.SuperHeroes
{
    public interface ISuperHeroesReadOnlyRepository
    {
        Task<SuperHeroListDTO> GetAll();
        Task<SuperHeroDTO?> GetById(int id);
        Task<bool> HeroNameExists(string name, int? excludeId = null);
        Task<int> GetCount();
    }
}
