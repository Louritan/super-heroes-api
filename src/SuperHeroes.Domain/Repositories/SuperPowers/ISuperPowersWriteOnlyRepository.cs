using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperPowers
{
    public interface ISuperPowersWriteOnlyRepository
    {
        Task Add(SuperPower superPower);
    }
}
