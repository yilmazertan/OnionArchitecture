using AutoMapper;
using MediatR;
using OnionArchitecture.Application.Repositories;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory
{
    public class GetAllProductWithCategoryQueryHandler : IRequestHandler<GetAllProductWithCategoryQueryRequest, List<ProductwithCategoryDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductWithCategoryQueryHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }



        public async Task<List<ProductwithCategoryDto>> Handle(GetAllProductWithCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllAsync(x => !x.IsDeleted, x => x.Category);
            return _mapper.Map<List<ProductwithCategoryDto>>(result);
        }
    }
}
