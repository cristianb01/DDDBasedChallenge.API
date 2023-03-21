using AutoMapper;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Domain.Entities;

namespace DDDBasedChallenge.Application.Mapping
{
    internal class EntityToDTOProfile : Profile
    {
        public EntityToDTOProfile() 
        {
            CreateMap<Product, ProductResponseDTO>();
        }
    }
}
