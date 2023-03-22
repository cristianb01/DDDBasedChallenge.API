using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;

namespace DDDBasedChallenge.Application.Features
{
    public interface ICategoryService
    {
        Task<Response<CategoryResponseDTO>> Create(CategoryRequestDTO categoryRequest, CancellationToken cancellationToken);
        Task<IEnumerable<CategoryResponseDTO>> GetAll(CancellationToken cancellationToken);
    }
}