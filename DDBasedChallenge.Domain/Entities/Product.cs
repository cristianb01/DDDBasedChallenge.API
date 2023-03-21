using DDDBasedChallenge.Domain.Abstract;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; private set; }
        public short QuantityInPackage { get; private set; }
        public bool IsNew { get; private set; }
        public int CategoryId { get; private set; }



        private Product(string name, short quantityInPackage, int categoryId)
        {
            Name = name;
            QuantityInPackage = quantityInPackage;
            CategoryId = categoryId;
        }

        public static Product Create(string name, short quantityInPackage, int categoryId)
        {
            var createdProduct = new Product(name, quantityInPackage, categoryId);
            createdProduct.IsNew = true;

            return createdProduct;
        }

    }

}