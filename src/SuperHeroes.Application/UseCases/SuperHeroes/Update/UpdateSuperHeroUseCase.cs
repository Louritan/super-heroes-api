using AutoMapper;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.HeroesPowers;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Domain.Repositories.SuperPowers;
using SuperHeroes.Exception;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Update
{
    public class UpdateSuperHeroUseCase : IUpdateSuperHeroUseCase
    {
        private readonly ISuperHeroesUpdateOnlyRepository _superHeroesUpdateRepository;
        private readonly ISuperHeroesReadOnlyRepository _superHeroesReadRepository;
        private readonly ISuperPowersReadOnlyRepository _superPowersReadRepository;
        private readonly IHeroesPowersWriteOnlyRepository _heroesPowersWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSuperHeroUseCase(
            ISuperHeroesUpdateOnlyRepository superHeroesUpdateRepository,
            ISuperHeroesReadOnlyRepository superHeroesReadRepository,
            ISuperPowersReadOnlyRepository superPowersReadRepository,
            IHeroesPowersWriteOnlyRepository heroesPowersWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _superHeroesUpdateRepository = superHeroesUpdateRepository;
            _superHeroesReadRepository = superHeroesReadRepository;
            _superPowersReadRepository = superPowersReadRepository;
            _heroesPowersWriteRepository = heroesPowersWriteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Execute(int id, RequestSuperHeroJson request)
        {
            Validate(request);

            var superHero = await _superHeroesUpdateRepository.GetById(id);

            if (superHero is null)
                throw new NotFoundException(ResourceErrorMessages.SUPER_HERO_NOT_FOUND_ERROR);

            var heroNameExists = await _superHeroesReadRepository.HeroNameExists(request.HeroName, id);

            if (heroNameExists)
                throw new ConflictException(ResourceErrorMessages.HERO_NAME_TAKEN_ERROR);

            var powersExists = await _superPowersReadRepository.Exists(request.SuperPowerIds);

            if (!powersExists)
                throw new NotFoundException(ResourceErrorMessages.SUPER_POWERS_NOT_FOUND_ERROR);

            _mapper.Map(request, superHero);
            _superHeroesUpdateRepository.Update(superHero);

            await _heroesPowersWriteRepository.DeleteHeroPowers(id);

            var heroPowers = request.SuperPowerIds.Select(powerId => new HeroPower
            {
                HeroId = id,
                PowerId = powerId,
            }).ToList();
            await _heroesPowersWriteRepository.Add(heroPowers);

            await _unitOfWork.Commit();
        }

        private void Validate(RequestSuperHeroJson request)
        {
            var validator = new SuperHeroValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
