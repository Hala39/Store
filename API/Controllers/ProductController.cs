using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Core.Helpers;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        public int PageSize { get; set; }
        private readonly IProductRepository _repo;
        private readonly IConfiguration _config;

        public ProductController(IProductRepository repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync
        (
            [FromQuery] PaginationFilter filter,
            string orderBy, 
            string searchString, 
            int? categoryId,
            int? pageIndex
            )
        {
            PageSize = _config.GetValue<int>("PageSize");
            return Ok(await _repo.GetProductsAsync(filter, orderBy, searchString, categoryId, pageIndex));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByIdAsync(int id)
        {
            return Ok(await _repo.GetProductByIdAsync(id));
        }

    }
}