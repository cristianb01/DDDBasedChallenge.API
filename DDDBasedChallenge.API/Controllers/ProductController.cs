﻿using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace DDDBasedChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("get-all")]
        public Task<IEnumerable<ProductResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            return this._productService.GetAll(cancellationToken);
        }

        [HttpPost]
        public Task<Response<ProductResponseDTO>> Create(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken)
        {
            return this._productService.Create(productRequestDTO, cancellationToken);
        }

        [HttpPut("update-name")]
        public Task<Response<ProductResponseDTO>> UpdateName(string newName, int productId, CancellationToken cancellationToken) 
        { 
            return this._productService.SetNewName(newName, productId, cancellationToken);
        }

        [HttpDelete("{productId:int}")]
        public Task<Response<bool>> Delete(int productId, CancellationToken cancellationToken) 
        {
            return this._productService.Delete(productId, cancellationToken);
        }

        [HttpPut("{productId:int}")]
        public Task<Response<ProductResponseDTO>> Update(int productId, ProductRequestDTO productRequestDTO, CancellationToken cancellationToken)
        {
            return this._productService.Update(productRequestDTO, productId, cancellationToken);
        }
    }
}
