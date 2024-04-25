﻿using AutoMapper;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts
{
    public class CreateProductDto
    {

        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<Product, CreateProductDto>().ReverseMap();
            }
        }
    }
}
