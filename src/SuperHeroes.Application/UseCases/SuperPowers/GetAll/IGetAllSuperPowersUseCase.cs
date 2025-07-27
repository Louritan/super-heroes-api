using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.SuperPowers.GetAll
{
    public interface IGetAllSuperPowersUseCase
    {
        Task<ResponseSuperPowersJson> Execute();
    }
}
