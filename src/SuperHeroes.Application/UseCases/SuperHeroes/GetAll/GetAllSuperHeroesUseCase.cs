using AutoMapper;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Repositories.SuperHeroes;

namespace SuperHeroes.Application.UseCases.SuperHeroes.GetAll
{
    public class GetAllSuperHeroesUseCase : IGetAllSuperHeroesUseCase
    {
        private readonly ISuperHeroesRepository _repository;
        private readonly IMapper _mapper;

        public GetAllSuperHeroesUseCase(ISuperHeroesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseSuperHeroesJson> Execute()
        {
            var superHeroesList = await _repository.GetAll();
            return _mapper.Map<ResponseSuperHeroesJson>(superHeroesList);
        }
    }
}
