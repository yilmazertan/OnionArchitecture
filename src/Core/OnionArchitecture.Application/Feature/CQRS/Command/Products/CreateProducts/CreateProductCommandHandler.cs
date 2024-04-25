using AutoMapper;
using FluentValidation;
using MediatR;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Services;
using OnionArchitecture.Application.Validator.Product;
using OnionArchitecture.Domain.CustomResult;
using OnionArchitecture.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using ResultStatus = OnionArchitecture.Domain.CustomResult.ResultStatus;

namespace OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        //private readonly IProductRepository productRepository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IProductService productService;

        public CreateProductCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IProductService productService)
        {

            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            this.productService = productService;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {



            await productService.CreateProduct(new CreateProductDto
            {

                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId

            });



            var result = await unitOfWork.SaveChangesAsync(cancellationToken);

            if (result > 0)
            {
                return new() { IsSuccess = true, message="Success" };
            }
            return new() {  IsSuccess = false, message = "Error" };


        }
    }
}
