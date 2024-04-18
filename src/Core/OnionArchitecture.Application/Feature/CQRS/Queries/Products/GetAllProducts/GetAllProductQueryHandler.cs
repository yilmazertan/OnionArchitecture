using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<ProductDto>>
    {
        private readonly IProductRepository  _productRepository;
        private readonly IMapper _mapper;
      
        public GetAllProductQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync(x=>!x.IsDeleted, x=>x.Category);
            
            return _mapper.Map<List<ProductDto>>(result);

        }
    }
}
