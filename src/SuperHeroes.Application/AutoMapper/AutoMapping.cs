using AutoMapper;
using SuperHeroes.Communication.Requests;
using SuperHeroes.Communication.Responses;
using SuperHeroes.Domain.DTOs;
using SuperHeroes.Domain.Entities;

namespace SuperHeroes.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestSuperHeroJson, SuperHero>();
            CreateMap<RequestRegisterSuperPowerJson, SuperPower>();
        }

        private void EntityToResponse()
        {
            CreateMap<SuperHero, ResponseSuperHeroRegisteredJson>();
            CreateMap<SuperHeroListDTO, ResponseSuperHeroesJson>();
            CreateMap<SuperHeroShortDTO, ResponseShortSuperHeroJson>();
            CreateMap<SuperPowerShortDTO, ResponseShortSuperPowerJson>();
            CreateMap<SuperHeroDTO, ResponseSuperHeroJson>();
            CreateMap<SuperPowerDTO, ResponseSuperPowerJson>();

            CreateMap<SuperPower, ResponseSuperPowerRegisteredJson>();
            CreateMap<SuperPower, ResponseSuperPowerJson>();
        }
    }
}
