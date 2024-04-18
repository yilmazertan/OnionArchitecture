using OnionArchitecture.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Domain.Entities
{
    public class Category : EntityBase, IEntity
    {
        
        public string Definition { get; set; }
        public List<Product>? Products { get; set; }
    }
}
