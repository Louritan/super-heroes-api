using FluentValidation;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Exception;

namespace SuperHeroes.Application.UseCases.SuperHeroes
{
    public class SuperHeroValidator : AbstractValidator<RequestSuperHeroJson>
    {
        public SuperHeroValidator()
        {
            RuleFor(superHero => superHero.Name).NotEmpty().WithMessage(ResourceErrorMessages.NAME_REQUIRED_ERROR);
            RuleFor(superHero => superHero.HeroName).NotEmpty().WithMessage(ResourceErrorMessages.HERO_NAME_REQUIRED_ERROR);
            RuleFor(superHero => superHero.SuperPowerIds)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.SUPER_POWER_REQUIRED_ERROR)
                .Must(ids => ids.Distinct().Count() == ids.Count())
                .WithMessage(ResourceErrorMessages.SUPER_POWER_DUPLICATED_ERROR);
            RuleFor(superHero => superHero.BirthDate)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.BIRTH_DATE_REQUIRED_ERROR)
                .Must(date => date.Kind == DateTimeKind.Utc)
                .WithMessage(ResourceErrorMessages.BIRTH_DATE_FORMAT_ERROR)
                .LessThan(DateTime.Now)
                .WithMessage(ResourceErrorMessages.FUTURE_BIRTH_DATE_ERROR);
            RuleFor(superHero => superHero.Height).NotEmpty().WithMessage(ResourceErrorMessages.HEIGHT_REQUIRED_ERROR);
            RuleFor(superHero => superHero.Weight).NotEmpty().WithMessage(ResourceErrorMessages.WEIGHT_REQUIRED_ERROR);
        }
    }
}
