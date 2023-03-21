using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Persistence.Repositories
{
    public class CategoryRepository
    {
        private readonly DDDBaseChallengeContext _context;

        public CategoryRepository(DDDBaseChallengeContext context)
        {
            _context = context;
        }

        public async Task<Category> AddAsync(Category category, CancellationToken cancellationToken)
        {
            var addedCategory = (await this._context.Categories.AddAsync(category, cancellationToken)).Entity;

            return addedCategory;
        }
    }
}
