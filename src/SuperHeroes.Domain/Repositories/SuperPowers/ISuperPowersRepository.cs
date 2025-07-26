using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperPowers
{
    public interface ISuperPowersRepository
    {
        Task Add(SuperPower superPower);
        Task<List<int>> GetExistingIds(List<int> superPowerIds);
    }
}
