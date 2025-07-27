using AutoMapper;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.Entities;
using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.SuperPowers;
using SuperHeroes.Exception.ExceptionsBase;

namespace SuperHeroes.Application.UseCases.SuperPowers.Register
{
    public class RegisterSuperPowerUseCase : IRegisterSuperPowerUseCase
    {
        private readonly ISuperPowersWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterSuperPowerUseCase(
            ISuperPowersWriteOnlyRepository repository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseSuperPowerRegisteredJson> Execute(RequestRegisterSuperPowerJson request)
        {
            Validate(request);

            var entity = _mapper.Map<SuperPower>(request);
            await _repository.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseSuperPowerRegisteredJson>(entity);
        }

        private void Validate(RequestRegisterSuperPowerJson request)
        {
            var validator = new RegisterSuperPowerValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
