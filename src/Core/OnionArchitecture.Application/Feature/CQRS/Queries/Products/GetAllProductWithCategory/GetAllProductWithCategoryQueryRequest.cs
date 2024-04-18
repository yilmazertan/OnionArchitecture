using MediatR;

namespace OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory
{
    public class GetAllProductWithCategoryQueryRequest : IRequest<List<ProductwithCategoryDto>>
    {
    }
}
