using SuperHeroes.Communication.Requests;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Update
{
    public interface IUpdateSuperHeroUseCase
    {
        Task Execute(int id, RequestSuperHeroJson request);
    }
}
