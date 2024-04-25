using AutoMapper;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Mappings
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductwithCategoryDto>();
            CreateMap<Product, GetAllProductDto>();
        }
    }
}
