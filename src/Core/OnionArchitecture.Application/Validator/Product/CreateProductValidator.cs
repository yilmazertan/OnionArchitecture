using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts;

namespace OnionArchitecture.Application.Validator.Product
{
    public class CreateProductValidator:AbstractValidator<CreateProductCommandRequest>
    {

        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Ürün adı boş geçilemez");
            RuleFor(p => p.Price).GreaterThanOrEqualTo(1).WithMessage("Fiyat 1 den büyük olmalıdır");
        }
    }
}
