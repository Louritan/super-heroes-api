namespace SuperHeroes.Application.UseCases.SuperHeroes.Delete
{
    public interface IDeleteSuperHeroUseCase
    {
        Task Execute(int id);
    }
}
