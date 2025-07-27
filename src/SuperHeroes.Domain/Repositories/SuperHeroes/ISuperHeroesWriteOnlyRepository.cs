using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Domain.Repositories.SuperHeroes
{
    public interface ISuperHeroesWriteOnlyRepository
    {
        Task Add(SuperHero superHero);
        /// <summary>
        /// Returns <c>true</c> if the hero was deleted successfully; otherwise, returns <c>false</c>
        /// </summary>
        /// <param name="id">The ID of the hero to be deleted</param>
        /// <returns><c>true</c> if the hero was deleted; otherwise, <c>false</c></returns>
        Task<bool> Delete(int id);
    }
}
