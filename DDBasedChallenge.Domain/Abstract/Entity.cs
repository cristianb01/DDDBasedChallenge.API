using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Domain.Abstract
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
        public DateTime CreationDate { get; protected set; }
        public DateTime UpdatedDate { get; protected set; }
        public bool IsDeleted { get; protected set; }
    }
}
