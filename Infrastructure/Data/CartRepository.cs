using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Wrappers;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartRepository(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ServiceResponse<CartDto>> AddToCart(ItemDto newItem)
        {
            ServiceResponse<CartDto> response = new ServiceResponse<CartDto>();

            var cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == GetUserId());

            if(cart == null) {
                cart = new Cart {
                    UserId = GetUserId()
                };
            }

            Item item = new Item {
                Category = newItem.Category,
                PictureUrl = newItem.PictureUrl,
                Price = newItem.Price,
                Quantity = newItem.Quantity,
                Size = newItem.Size,
                Color = newItem.Color, 
                ProductId = newItem.ProductId,
                Cart = cart
            };

            IQueryable<Item> itemsIQ = from i in _context.Items
                select i;

            var count = itemsIQ.Where(i => i.CartId == cart.Id).Count();

            if(_context.Items.Any(i => i.CartId == cart.Id && i.ProductId == item.ProductId))
            {
                response.Message = "This item is already added to your cart!";
                response.Success = false;
            }
            else if(count >= 5) 
            {
                response.Message = "You have reached the maximum of items that you can add to your basket!";
                response.Success = false;
            }

            else {
                await _context.Items.AddAsync(item);
                await _context.SaveChangesAsync();
                var data = await _context.Carts.FirstOrDefaultAsync(c => c.Id == cart.Id);
            }

            response.Data = _mapper.Map<CartDto>(cart);
            return response;

        }

        public async Task<ServiceResponse<CartDto>> EmptyCart()
        {
            ServiceResponse<CartDto> response = new ServiceResponse<CartDto>();
            Cart cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());

            if(cart != null)
            {
                 _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Message = "Successfully deleted";
            }
            
            else 
            {
                response.Message = "Cart is empty!";
                response.Success = false;
            }

            return response;

        }

        public async Task<ServiceResponse<CartDto>> RemoveSpecificItem(int itemId)
        {
            ServiceResponse<CartDto> response = new ServiceResponse<CartDto>();
            Cart cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());
            
            var specificItem = await _context.Items.FirstOrDefaultAsync(i => i.CartId == cart.Id && i.Id == itemId);

            if(await _context.Items.AnyAsync(i => i.CartId == cart.Id && i.Id == itemId))
            {
                _context.Items.Remove(specificItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Message = "Cart is empty!";
            }
            response.Data = _mapper.Map<CartDto>(cart);
            return response;
        }

        public async Task<ServiceResponse<CartDto>> GetCart()
        {
            ServiceResponse<CartDto> response = new ServiceResponse<CartDto>();
            Cart cart = await _context.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());
            response.Data = _mapper.Map<CartDto>(cart);
            return response;
        }

        public async Task<ServiceResponse<CartDto>> UpdateItemInCart(ItemDto specificItem)
        {
            ServiceResponse<CartDto> response = new ServiceResponse<CartDto>();
        try 
        {
            Cart cart = await _context.Carts.FirstOrDefaultAsync(c => c.UserId == GetUserId());
            Item updated = await _context.Items.FirstOrDefaultAsync(c => c.CartId == cart.Id && c.Id == specificItem.Id);
            updated.Category = specificItem.Category;
            updated.PictureUrl = specificItem.PictureUrl;
            updated.Price = specificItem.Price;
            updated.Color = specificItem.Color;
            updated.Size = specificItem.Size;
            updated.Quantity = specificItem.Quantity;
            updated.ProductId = specificItem.ProductId;

            _context.Items.Update(updated);
            await _context.SaveChangesAsync();

           response.Data = _mapper.Map<CartDto>(cart);
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;

        }

            return response;
        }

        //GetUserId
        int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

    }
}