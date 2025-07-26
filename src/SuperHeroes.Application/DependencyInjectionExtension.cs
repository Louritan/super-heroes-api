using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.Application.AutoMapper;
using SuperHeroes.Application.UseCases.SuperHeroes.GetAll;
using SuperHeroes.Application.UseCases.SuperHeroes.Register;

namespace SuperHeroes.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(cfg => { }, typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IRegisterSuperHeroUseCase, RegisterSuperHeroUseCase>();
            services.AddScoped<IGetAllSuperHeroesUseCase, GetAllSuperHeroesUseCase>();
        }
    }
}
