using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperPowers
{
    public interface ISuperPowersReadOnlyRepository
    {
        Task<bool> Exists(List<int> superPowerIds);
        Task<List<SuperPower>> GetAll();
        Task<int> GetCount();
    }
}
