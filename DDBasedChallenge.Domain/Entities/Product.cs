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
        public DateTime CreationDate { get; private set; }

        public int CategoryId { get; private set; }
        public Category Category { get; set; }

        private Product(string name, short quantityInPackage, int categoryId, DateTime creationDate)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            CategoryId = categoryId;
            CreationDate = creationDate;
        }

        public static Product Create(string name, short quantityInPackage, int categoryId, DateTime creationDate)
        {
            var createdProduct = new Product(name, quantityInPackage, categoryId, creationDate);
            createdProduct.IsNew = creationDate > new DateTime(2023, 01, 01);

            return createdProduct;
        }

        public void SetName(string name)
        {
            this.Name = name;
            this.UpdatedDate= DateTime.Now;
        }

        public void Update(string name, short quantityInPackage)
        {
            this.Name = name;
            this.QuantityInPackage = quantityInPackage;
            this.UpdatedDate = DateTime.Now;
        }


        public class Validator : AbstractValidator<Product>
        {
            public Validator()
            {
                RuleFor(x => x.Name).NotEmpty().WithMessage("Name can not be empty");
                RuleFor(x => x.QuantityInPackage).Must(x => x > 0).WithMessage("Quantity in package must be greater than 0");
                RuleFor(x => x.CategoryId).NotEmpty().WithMessage("The product should belong to a Category");
                RuleFor(x => x.CreationDate).NotEmpty().WithMessage("Creation date field must not be null");
            }
        }
    }

}