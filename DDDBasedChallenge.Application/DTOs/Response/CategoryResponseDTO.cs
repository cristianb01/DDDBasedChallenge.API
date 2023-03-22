using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.DTOs.Response
{
    public class CategoryResponseDTO
    {
        public int Id { get; set; }
        public List<ProductResponseDTO> Products { get; set; }
        public string Name { get; set; }
    }
}
