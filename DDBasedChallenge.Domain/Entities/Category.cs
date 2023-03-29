using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Domain.Abstract;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Category : Entity
    {
        private readonly List<Product> _products;

        public string Name { get; private set; }
        public IReadOnlyCollection<Product> Products => _products;

        public Category(string name)
        {
            this._products = new();
            Name = name;
        }

        public static Category Create(string name)
        {
            var category = new Category(name);

            return category;
        }

        public Category AddProduct(Product product)
        {
            this._products.Add(product);

            return this;
        }

        public class Validator : AbstractValidator<Category> 
        {
            public Validator()
            {
                RuleFor(x=> x.Name).NotEmpty().WithMessage("Category name can not be empty");
            }
        }

    }
}
