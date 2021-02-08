using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class CartController : ControllerBase
    {
        private readonly ICartRepository _repo;

        public CartController(ICartRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetCart()
        {
            return Ok(await _repo.GetCart());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(ItemDto item)
        {
            return Ok(await _repo.AddToCart(item));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOneItem(ItemDto item)
        {
            return Ok(await _repo.UpdateItemInCart(item));
        }

        [HttpDelete]
        public async Task<IActionResult> EmptyCart()
        {
            return Ok(await _repo.EmptyCart());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveOneItem(int id)
        {
            return Ok(await _repo.RemoveSpecificItem(id));
        }

    }
}