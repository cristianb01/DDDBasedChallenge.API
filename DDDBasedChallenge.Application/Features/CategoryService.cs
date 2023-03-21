using AutoMapper;
using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Application.Interfaces.Repositories;
using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Features
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<Response<CategoryResponseDTO>> Create(CategoryRequestDTO categoryRequest, CancellationToken cancellationToken)
        {
            var response = Category.Create(this._mapper.Map<List<Product>>(categoryRequest.Products), categoryRequest.Name);

            if (!response.Succeeded)
            {
                return new Response<CategoryResponseDTO>(response.Message);
            }

            var addedCategory = await this._repository.AddAsync(response.Data, cancellationToken);

            return new Response<CategoryResponseDTO>(_mapper.Map<CategoryResponseDTO>(addedCategory));
        }
    }
}
