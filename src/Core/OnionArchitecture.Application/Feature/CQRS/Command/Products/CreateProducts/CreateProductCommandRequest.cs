using MediatR;
using OnionArchitecture.Domain.CustomResult;


namespace OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>

    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
    }
}
