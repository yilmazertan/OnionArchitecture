using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Application.Repositories;
using OnionArchitecture.Domain.Entities;

namespace OnionArchitecture.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;
        public CategoriesController(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Catergory(Category category)
        {
            var result = await categoryRepository.AddAsync(category);
          await  unitOfWork.SaveChangesAsync();
            return Ok(result);

        }
    }
}
