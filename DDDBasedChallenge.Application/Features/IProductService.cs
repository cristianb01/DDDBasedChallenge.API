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
        Task<Response<ProductResponseDTO>> SetNewName(string newName, int productId, CancellationToken cancellationToken);
        Task<Response<bool>> Delete(int productId, CancellationToken cancellationToken);
        Task<Response<ProductResponseDTO>> Update(ProductRequestDTO productRequestDTO, int productId, CancellationToken cancellationToken);
    }
}