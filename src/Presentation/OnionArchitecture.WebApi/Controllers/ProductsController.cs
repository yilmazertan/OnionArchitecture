using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProducts;
using OnionArchitecture.Application.Feature.CQRS.Queries.Products.GetAllProductWithCategory;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator, IProductRepository productRepository)
        {
            _mediator = mediator;
            _productRepository = productRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            var result = await _productRepository.AddAsync(product);
            return Ok(result);

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
