using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Application.DTOs.Request;
using DDDBasedChallenge.Domain.Entities;

namespace DDDBasedChallenge.Application.Features
{
    public interface IProductService
    {
        Task<Response<Product>> Create(ProductRequestDTO product, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAll(CancellationToken cancellationToken);
    }
}