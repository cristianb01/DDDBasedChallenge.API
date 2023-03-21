using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
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

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken)
        {
            return default;
        }

        public async Task<Response<Product>> Create(ProductRequestDTO productDTO, CancellationToken cancellationToken)
        {
            var validationResult = new ProductRequestDTO.Validator().Validate(productDTO);

            if (!validationResult.IsValid)
            {   
                return new Response<Product>(validationResult.ToString());
            }

            var createdProduct = Product.Create(productDTO.Name, productDTO.QuantityInPackage, productDTO.CategoryId);

            await this._productRepository.AddAsync(createdProduct, cancellationToken);

            return new Response<Product>(createdProduct);
        }

    }
}
