using SuperHeroes.Communication.Responses;

namespace SuperHeroes.Application.UseCases.Metrics.GetAll
{
    public interface IGetAllMetricsUseCase
    {
        Task<ResponseMetricsJson> Execute();
    }
}
