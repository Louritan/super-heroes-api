using AutoMapper;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.HeroesPowers;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Domain.Repositories.SuperPowers;
using SuperHeroes.Exception;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Register
{
    public class RegisterSuperHeroUseCase : IRegisterSuperHeroUseCase
    {
        private readonly ISuperHeroesReadOnlyRepository _superHeroesReadRepository;
        private readonly ISuperHeroesWriteOnlyRepository _superHeroesWriteRepository;
        private readonly ISuperPowersReadOnlyRepository _superPowersReadRepository;
        private readonly IHeroesPowersWriteOnlyRepository _heroesPowersWriteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterSuperHeroUseCase(
            ISuperHeroesReadOnlyRepository superHeroesReadRepository,
            ISuperHeroesWriteOnlyRepository superHeroesWriteRepository,
            ISuperPowersReadOnlyRepository superPowersReadRepository,
            IHeroesPowersWriteOnlyRepository heroesPowersWriteRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _superHeroesReadRepository = superHeroesReadRepository;
            _superHeroesWriteRepository = superHeroesWriteRepository;
            _superPowersReadRepository = superPowersReadRepository;
            _heroesPowersWriteRepository = heroesPowersWriteRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseSuperHeroRegisteredJson> Execute(RequestSuperHeroJson request)
        {
            Validate(request);

            var heroNameExists = await _superHeroesReadRepository.HeroNameExists(request.HeroName);

            if (heroNameExists)
                throw new ConflictException(ResourceErrorMessages.HERO_NAME_TAKEN_ERROR);

            var powersExists = await _superPowersReadRepository.Exists(request.SuperPowerIds);

            if (!powersExists)
                throw new NotFoundException(ResourceErrorMessages.SUPER_POWERS_NOT_FOUND_ERROR);

            var superHero = _mapper.Map<SuperHero>(request);
            await _superHeroesWriteRepository.Add(superHero);

            var heroPowers = request.SuperPowerIds.Select(powerId => new HeroPower
            {
                SuperHero = superHero,
                PowerId = powerId,
            }).ToList();
            await _heroesPowersWriteRepository.Add(heroPowers);

            try
            {
                await _unitOfWork.Commit();
            }
            catch (System.Exception ex)
            {
                Console.Error.WriteLine($"Erro no Commit: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.Error.WriteLine($"Inner exception: {ex.InnerException.Message}");
                    Console.Error.WriteLine(ex.InnerException.StackTrace);
                }
                else
                {
                    Console.Error.WriteLine(ex.StackTrace);
                }

                throw;
            }

            return _mapper.Map<ResponseSuperHeroRegisteredJson>(superHero);
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
