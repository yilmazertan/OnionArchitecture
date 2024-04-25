using AutoMapper;
using OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Persistance.Services.Products
{

    public class ProductService : IProductService
    {

        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork, IProductWriteRepository productWriteRepository)
        {
            
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.productWriteRepository = productWriteRepository;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            var product = mapper.Map<Product>(createProductDto);
            await productWriteRepository.AddAsync(product);
        }

        public async Task<IList<GetAllProductDto>> GetAllProducts(CancellationToken cancellationToken)
        {

            var result=await unitOfWork.ProductsRead.GetAllAsync();
            return mapper.Map<List<GetAllProductDto>>(result);

        }

       
    }
}
