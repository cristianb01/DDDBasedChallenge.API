using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Application.DTOs.Response;
using DDDBasedChallenge.Domain.Entities;

namespace DDDBasedChallenge.Application.Features
{
    public interface IProductService
    {
        Task<Response<ProductResponseDTO>> Create(ProductRequestDTO product, CancellationToken cancellationToken);
        Task<IEnumerable<ProductResponseDTO>> GetAll(CancellationToken cancellationToken);
    }
}