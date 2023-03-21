using DDDBasedChallenge.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Purchase : Entity
    {
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
        public IList<ProductPurchase> Products { get; set; } = new List<ProductPurchase>();
    }
}
