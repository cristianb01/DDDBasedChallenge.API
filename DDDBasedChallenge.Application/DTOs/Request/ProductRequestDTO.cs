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
        public DateTime CreationDate{ get; set; }

        public int CategoryId { get; set; }

        
    }
}
