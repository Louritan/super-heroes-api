using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Domain.Repositories.SuperPowers;

namespace SuperHeroes.Application.UseCases.Metrics.GetAll
{
    public class GetAllMetricsUseCase : IGetAllMetricsUseCase
    {
        private readonly ISuperHeroesReadOnlyRepository _superHeroesReadRepository;
        private readonly ISuperPowersReadOnlyRepository _superPowersReadRepository;

        public GetAllMetricsUseCase(
            ISuperHeroesReadOnlyRepository superHeroesReadRepository,
            ISuperPowersReadOnlyRepository superPowersReadRepository
        )
        {
            _superHeroesReadRepository = superHeroesReadRepository;
            _superPowersReadRepository = superPowersReadRepository;
        }

        public async Task<ResponseMetricsJson> Execute()
        {
            var totalHeroes = await _superHeroesReadRepository.GetCount();
            var totalPowers = await _superPowersReadRepository.GetCount();
            return new ResponseMetricsJson
            {
                TotalHeroes = totalHeroes,
                TotalPowers = totalPowers,
            };
        }
    }
}
