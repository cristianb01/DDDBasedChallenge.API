using DDDBasedChallenge.Domain.Abstract;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public short QuantityInPackage { get; set; }

        public int CategoryId { get; set; }
    }
}