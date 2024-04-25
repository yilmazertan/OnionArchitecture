using OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Services
{
    public interface IProductService
    {
        Task CreateProduct(CreateProductDto createProductDto);
        Task<IList<GetAllProductDto>> GetAllProducts(CancellationToken cancellationToken);
    }
}
