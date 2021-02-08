using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductColorController : ControllerBase
    {
        private readonly IProductColorRepository _repo;

        public ProductColorController(IProductColorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _repo.GetProductColorByProductId(id));
        }
    }
}