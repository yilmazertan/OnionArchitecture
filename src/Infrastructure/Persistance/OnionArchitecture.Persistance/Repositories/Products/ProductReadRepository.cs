using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Domain.Entities;
using OnionArchitecture.Domain.Entities.Common;
using OnionArchitecture.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Repositories.Products
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        public ProductReadRepository(AppDbContext context) : base(context)
        {
        }
    }
}
