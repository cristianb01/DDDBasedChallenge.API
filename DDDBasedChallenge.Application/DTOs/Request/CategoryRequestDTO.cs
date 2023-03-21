using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.DTOs.Request
{
    public class CategoryRequestDTO
    {
        public List<ProductRequestDTO> Products { get; set; }
        public string Name { get; set; }
    }
}
