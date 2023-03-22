using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> AddAsync(Category category, CancellationToken cancellationToken);
        Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);
    }
}
