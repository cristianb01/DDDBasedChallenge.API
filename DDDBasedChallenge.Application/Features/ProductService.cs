using AutoMapper;
using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Application.Interfaces.Repositories;
using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Features
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            var products = await this._productRepository.GetAllAsync(cancellationToken);

            return this._mapper.Map<IEnumerable<ProductResponseDTO>>(products);
        }

        public async Task<Response<ProductResponseDTO>> Create(ProductRequestDTO productDTO, CancellationToken cancellationToken)
        {
            var createdProduct = Product.Create(productDTO.Name, productDTO.QuantityInPackage, productDTO.CategoryId, productDTO.CreationDate);

            var validationResult = new Product.Validator().Validate(createdProduct);

            if (!validationResult.IsValid)
            {   
                return new Response<ProductResponseDTO>(validationResult.ToString());
            }

            await this._productRepository.AddAsync(createdProduct, cancellationToken);

            return new Response<ProductResponseDTO>(_mapper.Map<ProductResponseDTO>(createdProduct));
        }

    }
}
