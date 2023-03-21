using DDDBasedChallenge.Application.Communication;
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

        [HttpGet]
        public Task<IEnumerable<ProductResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            return this._productService.GetAll(cancellationToken);
        }

        [HttpPost]
        public  Task<Response<ProductResponseDTO>> Create(ProductRequestDTO productRequestDTO, CancellationToken cancellationToken)
        {
            return this._productService.Create(productRequestDTO, cancellationToken);
        }
    }
}
