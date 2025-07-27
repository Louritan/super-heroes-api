using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.SuperHeroes.GetById
{
    public interface IGetSuperHeroByIdUseCase
    {
        Task<ResponseSuperHeroJson> Execute(int id);
    }
}
