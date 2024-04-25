using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Repositories;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory
{
    public class GetAllProductWithCategoryQueryHandler : IRequestHandler<GetAllProductWithCategoryQueryRequest, List<ProductwithCategoryDto>>
    {
         
        private readonly IMapper _mapper;

        public GetAllProductWithCategoryQueryHandler(  IMapper mapper)
        {
            
            _mapper = mapper;
        }



        public async Task<List<ProductwithCategoryDto>> Handle(GetAllProductWithCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            //var result = await _productRepository.GetAllAsync(null, x => x.Category);
            //return _mapper.Map<List<ProductwithCategoryDto>>(result);
            return null;
        }
    }
}
