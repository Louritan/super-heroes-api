using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.SuperHeroes.GetAll
{
    public interface IGetAllSuperHeroesUseCase
    {
        Task<ResponseSuperHeroesJson> Execute();
    }
}
