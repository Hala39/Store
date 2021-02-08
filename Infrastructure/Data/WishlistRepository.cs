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
    public class WishlistRepository : IWishlistRepository
    {
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;

        public WishlistRepository(DataContext context, IHttpContextAccessor httpContextAccessor, IMapper mapper)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<WishlistDto>> AddToWishlist(WishDto newWish)
        {
            ServiceResponse<WishlistDto> response = new ServiceResponse<WishlistDto>();
            var wishlist = await  _context.Wishlists.FirstOrDefaultAsync(w => w.UserId == GetUserId());

            if(wishlist == null) {
                wishlist = new Wishlist {
                    UserId = GetUserId()
                };
            }

            Wish wish = new Wish {
                ProductId = newWish.ProductId,
                Category = newWish.Category,
                Price = newWish.Price,
                PictureUrl = newWish.PictureUrl,
                OPrice = newWish.OPrice,
                Wishlist = wishlist
            };

            IQueryable<Wish> wishesIQ = from i in _context.Wishes
                select i;

            var count = wishesIQ.Where(i => i.WishlistId == wishlist.Id).Count();

            if(_context.Wishes.Any(i => i.WishlistId == wishlist.Id && i.ProductId == wish.ProductId))
            {
                await RemoveSpecificWish(wish.ProductId);
                response.Message = "removed";
            }

            else if(count >= 5) 
            {
                response.Message = "You have reached the maximum of items that you can add to your basket!";
                response.Success = false;
            }

            else 
            {
                await _context.Wishes.AddAsync(wish);
                await _context.SaveChangesAsync();
                response.Message = "Done";
            }

            response.Data = _mapper.Map<WishlistDto>(wishlist);
            return response;
        }


        public async Task<ServiceResponse<WishlistDto>> EmptyWishlist()
        {
            ServiceResponse<WishlistDto> response = new ServiceResponse<WishlistDto>();
            Wishlist wishlist = await _context.Wishlists
                .Include(c => c.Wishes)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());

            if(wishlist != null)
            {
                 _context.Wishlists.Remove(wishlist);
                await _context.SaveChangesAsync();
                response.Data = null;
                response.Message = "Successfully deleted";
            }
            
            else 
            {
                response.Message = "Wishlist is empty!";
                response.Success = false;
            }

            return response;
        }

        public async Task<ServiceResponse<WishlistDto>> GetWishlist()
        {
            ServiceResponse<WishlistDto> response = new ServiceResponse<WishlistDto>();
            Wishlist wishlist = await _context.Wishlists
                .Include(c => c.Wishes)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());
            response.Data = _mapper.Map<WishlistDto>(wishlist);
            return response;
        }

        public async Task<ServiceResponse<WishlistDto>> RemoveSpecificWish(int productId)
        {
            ServiceResponse<WishlistDto> response = new ServiceResponse<WishlistDto>();
            Wishlist wishlist = await _context.Wishlists
                .Include(c => c.Wishes)
                .FirstOrDefaultAsync(c => c.UserId == GetUserId());
            
            var specificItem = await _context.Wishes.FirstOrDefaultAsync(i => i.WishlistId == wishlist.Id);

            if(await _context.Wishes.AnyAsync(i => i.WishlistId == wishlist.Id && i.ProductId == productId))
            {
                _context.Wishes.Remove(specificItem);
                await _context.SaveChangesAsync();
            }
            else
            {
                response.Success = false;
                response.Message = "Cart is empty!";
            }
            response.Data = _mapper.Map<WishlistDto>(wishlist);
            return response;
        }

        
        int GetUserId() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}