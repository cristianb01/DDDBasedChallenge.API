using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Application.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDDBasedChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public Task<Response<CategoryResponseDTO>> Create(CategoryRequestDTO categoryRequestDTO, CancellationToken cancellationToken) 
        {
            return this._categoryService.Create(categoryRequestDTO, cancellationToken);
        }

        [HttpGet("get-all")]
        public Task<IEnumerable<CategoryResponseDTO>> GetAll(CancellationToken cancellationToken)
        {
            return this._categoryService.GetAll(cancellationToken);
        }
    }
}
