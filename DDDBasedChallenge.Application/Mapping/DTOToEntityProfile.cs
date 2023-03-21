using AutoMapper;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Mapping
{
    internal class DTOToEntityProfile : Profile
    {
        public DTOToEntityProfile()
        {
            CreateMap<CategoryRequestDTO, Category>();
            CreateMap<ProductRequestDTO, Product>();
        }
    }
}
