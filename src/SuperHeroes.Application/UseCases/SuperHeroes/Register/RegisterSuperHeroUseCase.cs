using AutoMapper;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Domain.Repositories.SuperPowers;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Register
{
    public class RegisterSuperHeroUseCase : IRegisterSuperHeroUseCase
    {
        private readonly ISuperHeroesRepository _superHeroesRepository;
        private readonly ISuperPowersRepository _superPowersRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterSuperHeroUseCase(
            ISuperHeroesRepository superHeroesRepository,
            ISuperPowersRepository superPowersRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _superHeroesRepository = superHeroesRepository;
            _superPowersRepository = superPowersRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseSuperHeroRegisteredJson> Execute(RequestRegisterSuperHeroJson request)
        {
            await Validate(request);

            var entity = _mapper.Map<SuperHero>(request);
            await _superHeroesRepository.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseSuperHeroRegisteredJson>(entity);
        }

        private async Task Validate(RequestRegisterSuperHeroJson request)
        {
            var validator = new RegisterSuperHeroValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }

            var existingIds = await _superPowersRepository.GetExistingIds(request.SuperPowerIds);
            var notFoundIds = request.SuperPowerIds.Except(existingIds).ToList();

            if (notFoundIds.Any())
            {
                var errorMessage = $"The following super powers were not found: {string.Join(", ", notFoundIds)}";
                throw new NotFoundException(errorMessage);
            }
        }
    }
}
