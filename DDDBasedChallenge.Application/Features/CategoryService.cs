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
            var createdCategory = Category.Create(categoryRequest.Name);

            var validationResult = new Category.Validator().Validate(createdCategory);

            if (!validationResult.IsValid)
            {
                return new Response<CategoryResponseDTO>(validationResult.ToString());
            }

            var addedCategory = await this._repository.AddAsync(createdCategory, cancellationToken);

            return new Response<CategoryResponseDTO>(_mapper.Map<CategoryResponseDTO>(addedCategory));
        }

        public async Task<IEnumerable<CategoryResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            var categories = await this._repository.GetAllAsync(cancellationToken);

            return this._mapper.Map<IEnumerable<CategoryResponseDTO>>(categories);
        }
    }
}
