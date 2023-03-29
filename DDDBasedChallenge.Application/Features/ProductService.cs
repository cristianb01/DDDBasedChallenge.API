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

            var addedProduct = await this._productRepository.AddAsync(createdProduct, cancellationToken);

            return new Response<ProductResponseDTO>(_mapper.Map<ProductResponseDTO>(addedProduct));
        }

        public async Task<Response<ProductResponseDTO>> SetNewName(string newName, int productId, CancellationToken cancellationToken)
        {
            var product = await this._productRepository.GetByIdAsync(productId, cancellationToken);

            if (product is null) 
            {
                return new Response<ProductResponseDTO>("Could not find any product with specified id");
            }

            product.SetName(newName);

            var validationResult = new Product.Validator().Validate(product);

            if (!validationResult.IsValid) 
            {
                return new Response<ProductResponseDTO>(validationResult.ToString());
            }

            return new Response<ProductResponseDTO>(_mapper.Map<ProductResponseDTO>(validationResult));
        }

        public async Task<Response<bool>> Delete(int productId, CancellationToken cancellationToken)
        {
            var existingProduct = await this._productRepository.GetByIdAsync(productId, cancellationToken);

            if (existingProduct is null)
            {
                return new Response<bool>("Specified product does not exist");
            }

            var isDeleted = await this._productRepository.Delete(existingProduct);

            if (isDeleted)
            {
                return new Response<bool>(true);
            }
            else
            {
                return new Response<bool>("Could not delete product");
            }

        }

        public async Task<Response<ProductResponseDTO>> Update(ProductRequestDTO productRequestDTO, int productId, CancellationToken cancellationToken)
        {
            var existingProduct = await this._productRepository.GetByIdAsync(productId, cancellationToken);

            if (existingProduct is null)
            {
                return new Response<ProductResponseDTO>("Specified product does not exist");
            }

            existingProduct.Update(productRequestDTO.Name, productRequestDTO.QuantityInPackage);

            var validationResult = new Product.Validator().Validate(existingProduct);

            if (!validationResult.IsValid)
            {
                return new Response<ProductResponseDTO>(validationResult.ToString());
            }

            var updateResult = await this._productRepository.Update(existingProduct);

            return new Response<ProductResponseDTO>(this._mapper.Map<ProductResponseDTO>(updateResult));

        }
    }
}
