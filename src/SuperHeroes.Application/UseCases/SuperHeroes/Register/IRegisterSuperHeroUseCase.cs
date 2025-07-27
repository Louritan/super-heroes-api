using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Register
{
    public interface IRegisterSuperHeroUseCase
    {
        Task<ResponseSuperHeroRegisteredJson> Execute(RequestSuperHeroJson request);
    }
}
