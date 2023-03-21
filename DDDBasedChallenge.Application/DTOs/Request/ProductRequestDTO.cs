using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.DTOs.Request
{
    public class ProductRequestDTO
    {
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }

        public int CategoryId { get; set; }

        public class Validator : AbstractValidator<ProductRequestDTO>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
                RuleFor(x => x.QuantityInPackage).NotEmpty().WithMessage("Please specify quantity in package");
                RuleFor(x => x.CategoryId).NotEmpty().WithMessage("The product should to a Category");
            }
        }
    }
}
