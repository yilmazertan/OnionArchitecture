using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, IList<GetAllProductDto>>
    {
        
        private readonly IMapper _mapper;
        private readonly IProductService productService;
        public GetAllProductQueryHandler(  IMapper mapper, IProductService productService)
        {
            
            _mapper = mapper;
            this.productService = productService;
        }

        public async Task<IList<GetAllProductDto>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            return await productService.GetAllProducts(cancellationToken);
        }
    }
}
