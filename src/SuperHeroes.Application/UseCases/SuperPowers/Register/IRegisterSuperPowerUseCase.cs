using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.SuperPowers.Register
{
    public interface IRegisterSuperPowerUseCase
    {
        Task<ResponseSuperPowerRegisteredJson> Execute(RequestRegisterSuperPowerJson request);
    }
}
