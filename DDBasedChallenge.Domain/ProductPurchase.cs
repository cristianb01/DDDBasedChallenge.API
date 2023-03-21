using DDDBasedChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Domain
{
    public class ProductPurchase
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int PurchaseId { get; set; }
        public Purchase Purchase { get; set; }

        public int Quantity { get; set; }
    }
}
