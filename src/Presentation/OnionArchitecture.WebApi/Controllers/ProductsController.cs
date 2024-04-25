using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Feature.CQRS.Command.Products.CreateProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Application.Repositories.Products;
using OnionArchitecture.Application.Validator.Product;
using OnionArchitecture.Domain.CustomResult;
using OnionArchitecture.Domain.Entities;
using System.Net;

namespace OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductReadRepository productReadRepository;
        private readonly IProductWriteRepository productWriteRepository;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator, IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _mediator = mediator;
            this.productReadRepository = productReadRepository;
            this.productWriteRepository = productWriteRepository;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Products(CreateProductCommandRequest request,ISender sender)
        {
            //var response = await _mediator.Send(request);
            var response = await _mediator.Send(request);
            return response.IsSuccess ? Ok(response) :
                );
            //return Ok(response);
            
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
        var result=   await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(result);

        }

        [HttpGet("[action]")]
        public async Task<IActionResult> ProductsWithCategory()
        {
            var result = await _mediator.Send(new GetAllProductWithCategoryQueryRequest());
            return Ok(result);

        }
    }
}
