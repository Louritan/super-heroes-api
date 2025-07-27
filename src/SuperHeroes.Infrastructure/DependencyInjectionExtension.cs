using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHeroes.Domain.Repositories;
using SuperHeroes.Domain.Repositories.HeroesPowers;
using SuperHeroes.Domain.Repositories.SuperHeroes;
using SuperHeroes.Domain.Repositories.SuperPowers;
using SuperHeroes.Infrastructure.DataAccess;
using SuperHeroes.Infrastructure.DataAccess.Repositories;

namespace SuperHeroes.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);
            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISuperHeroesReadOnlyRepository, SuperHeroesRepository>();
            services.AddScoped<ISuperHeroesWriteOnlyRepository, SuperHeroesRepository>();
            services.AddScoped<ISuperPowersReadOnlyRepository, SuperPowersRepository>();
            services.AddScoped<ISuperPowersWriteOnlyRepository, SuperPowersRepository>();
            services.AddScoped<IHeroesPowersWriteOnlyRepository, HeroesPowersRepository>();
            services.AddScoped<ISuperHeroesUpdateOnlyRepository, SuperHeroesRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");
            services.AddDbContext<SuperHeroesDbContext>(options => options.UseNpgsql(connectionString));
        }
    }
}
