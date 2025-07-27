using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.HeroesPowers
{
    public interface IHeroesPowersWriteOnlyRepository
    {
        Task Add(List<HeroPower> heroPowers);
        Task DeleteHeroPowers(int superHeroId);
    }
}
