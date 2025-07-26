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
            CreateMap<RequestRegisterSuperHeroJson, SuperHero>();
        }

        private void EntityToResponse()
        {
            CreateMap<SuperHero, ResponseSuperHeroRegisteredJson>();
            CreateMap<SuperHeroListDTO, ResponseSuperHeroesJson>();
        }
    }
}
