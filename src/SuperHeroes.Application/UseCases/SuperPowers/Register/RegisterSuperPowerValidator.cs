using FluentValidation;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Exception;

namespace SuperHeroes.Application.UseCases.SuperPowers.Register
{
    public class RegisterSuperPowerValidator : AbstractValidator<RequestRegisterSuperPowerJson>
    {
        public RegisterSuperPowerValidator()
        {
            RuleFor(superPower => superPower.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED_ERROR);
            RuleFor(superPower => superPower.Description).NotEmpty().WithMessage(ResourceErrorMessages.DESCRIPTION_REQUIRED_ERROR);
        }
    }
}
