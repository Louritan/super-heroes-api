using AutoMapper;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Exception;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperHeroes.GetById
{
    public class GetSuperHeroByIdUseCase : IGetSuperHeroByIdUseCase
    {
        private readonly ISuperHeroesReadOnlyRepository _repository;
        private readonly IMapper _mapper;

        public GetSuperHeroByIdUseCase(ISuperHeroesReadOnlyRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseSuperHeroJson> Execute(int id)
        {
            var superHero = await _repository.GetById(id);

            if (superHero is null)
                throw new NotFoundException(ResourceErrorMessages.SUPER_HERO_NOT_FOUND_ERROR);

            return _mapper.Map<ResponseSuperHeroJson>(superHero);
        }
    }
}
