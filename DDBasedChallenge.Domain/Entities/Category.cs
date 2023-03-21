﻿using DDDBasedChallenge.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Domain.Entities
{
    public class Category : Entity
    {
        private readonly List<Product> _products;
        public string Name { get; set; }
        public IReadOnlyCollection<Product> Products => _products;


    }
}
