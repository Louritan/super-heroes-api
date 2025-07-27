using AutoMapper;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Repositories.SuperPowers;

namespace SuperHeroes.Application.UseCases.SuperPowers.GetAll
{
    public class GetAllSuperPowersUseCase : IGetAllSuperPowersUseCase
    {
        private readonly ISuperPowersReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSuperPowersUseCase(ISuperPowersReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseSuperPowersJson> Execute()
        {
            var superPowers = await _repository.GetAll();
            return new ResponseSuperPowersJson
            {
                SuperPowers = _mapper.Map<List<ResponseSuperPowerJson>>(superPowers)
            };
        }
    }
}
