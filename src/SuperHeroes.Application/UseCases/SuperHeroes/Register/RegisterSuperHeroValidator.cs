using FluentValidation;
using SuperHeroes.Communication.Requests;

namespace SuperHeroes.Application.UseCases.SuperHeroes.Register
{
    public class RegisterSuperHeroValidator : AbstractValidator<RequestRegisterSuperHeroJson>
    {
        public RegisterSuperHeroValidator()
        {
            RuleFor(superHero => superHero.Name).NotEmpty().WithMessage("Name is required!");
            RuleFor(superHero => superHero.HeroName).NotEmpty().WithMessage("HeroName is required!");
            RuleFor(superHero => superHero.SuperPowerIds)
                .NotEmpty()
                .WithMessage("SuperPowerIds must contain at least one super power!")
                .Must(ids => ids.Distinct().Count() == ids.Count())
                .WithMessage("SuperPowerIds must not contain duplicate values!");
            RuleFor(superHero => superHero.BirthDate).LessThan(DateTime.Now).WithMessage("BirthDate must be less than current date!");
            RuleFor(superHero => superHero.Height).GreaterThan(0).WithMessage("Height must be greater than zero!");
            RuleFor(superHero => superHero.Weight).GreaterThan(0).WithMessage("Weight must be greater than zero!");
        }
    }
}
