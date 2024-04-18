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

        // public Category Category { get; set; }




        //public Category Category { get; set; }

        //public class Category
        //{
        //    public string Definition { get; set; }

        //}


    }
    public class CategoryDto
    {
        public string Definition { get; set; }

    }



}
