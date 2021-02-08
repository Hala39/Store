using System.Threading.Tasks;
using Core.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class WishlistController : ControllerBase
    {
        private readonly IWishlistRepository _repo;

        public WishlistController(IWishlistRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetWishlist()
        {
            return Ok(await _repo.GetWishlist());
        }

        [HttpPost]
        public async Task<IActionResult> AddToWishlist(WishDto newWish)
        {
            return Ok(await _repo.AddToWishlist(newWish));
        }

        [HttpDelete]
        public async Task<IActionResult> EmptyWishlist()
        {
            return Ok(await _repo.EmptyWishlist());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveSpecicifcWish(int id)
        {
            return Ok(await _repo.RemoveSpecificWish(id));
        }
    }
}