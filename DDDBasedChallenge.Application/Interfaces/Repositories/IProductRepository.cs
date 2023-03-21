using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product, CancellationToken cancellationToken);
        Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);
        Task<Product> GetByIdAsync(int id);
    }
}
