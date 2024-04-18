using AutoMapper;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Mappings
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }
    }
}
