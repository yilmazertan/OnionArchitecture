using OnionArchitecture.Domain.CustomResult;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts
{
    public class CreateProductCommandResponse  
    {

        public bool IsSuccess { get; set; }
        public string  message { get; set; }

    }
}
