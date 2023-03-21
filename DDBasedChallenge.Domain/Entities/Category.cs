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

        public Category(List<Product> products, string name)
        {
            _products = products;
            Name = name;
        }

        public static Response<Category> Create(List<Product> products, string name)
        {
            var category = new Category(products, name);

            var validationResult = new Validator().Validate(category);

            if (!validationResult.IsValid) 
            { 
                return new Response<Category>(validationResult.ToString());
            }

            return new Response<Category>(category);
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
