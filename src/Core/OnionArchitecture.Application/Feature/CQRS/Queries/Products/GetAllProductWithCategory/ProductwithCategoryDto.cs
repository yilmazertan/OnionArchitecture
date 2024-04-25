using AutoMapper;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory
{
    public class ProductwithCategoryDto
    {


        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryDto Category { get; set; }



        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Product, ProductwithCategoryDto>();
            }
        }
    }


    public class CategoryDto
    {
        public string Definition { get; set; }


        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Category, CategoryDto>();
            }
        }
    }



}
