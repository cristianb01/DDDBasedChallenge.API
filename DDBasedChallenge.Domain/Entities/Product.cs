using DDDBasedChallenge.Application.Communication;
using DDDBasedChallenge.Domain.Abstract;
using FluentValidation;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public bool IsNew { get; private set; }
        public int CategoryId { get; private set; }
        public DateTime CreationDate { get; private set; }


        private Product(string name, short quantityInPackage, int categoryId, DateTime creationDate)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            CategoryId = categoryId;
            CreationDate = creationDate;
        }

        public static Response<Product> Create(string name, short quantityInPackage, int categoryId, DateTime creationDate)
        {
            var createdProduct = new Product(name, quantityInPackage, categoryId, creationDate);
            createdProduct.IsNew = creationDate > new DateTime(2023, 01, 01);

            var validationResult = new Validator().Validate(createdProduct);

            if(!validationResult.IsValid)
            {
                return new Response<Product>(validationResult.ToString());
            }
            return new Response<Product>(createdProduct);
        }

        public Response<Product> SetName(string name)
        {
            this.Name = name;
            this.UpdatedDate= DateTime.Now;

            var validationResult = new Validator().Validate(this);

            if(!validationResult.IsValid) 
            {
                return new Response<Product>(validationResult.ToString());
            }
            return new Response<Product>(this);
        }


        public class Validator : AbstractValidator<Product>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
                RuleFor(x => x.QuantityInPackage).NotEmpty().WithMessage("Please specify quantity in package");
                RuleFor(x => x.CategoryId).NotEmpty().WithMessage("The product should to a Category");
                RuleFor(x => x.CreationDate).NotEmpty().WithMessage("Creation date field must not be null");
            }
        }
    }

}