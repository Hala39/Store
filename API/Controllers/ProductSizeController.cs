 using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductSizeController : ControllerBase
    {
        private readonly IProductSizeRepository _repo;

        public ProductSizeController(IProductSizeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductSizes(int id)
        {
            return Ok(await _repo.GetProductSizesByProductId(id));
        }
    }
}