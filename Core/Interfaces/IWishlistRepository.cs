using System.Threading.Tasks;
using Core.Dtos;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface IWishlistRepository
    {
        Task<ServiceResponse<WishlistDto>> GetWishlist();
        Task<ServiceResponse<WishlistDto>> EmptyWishlist();
        Task<ServiceResponse<WishlistDto>> AddToWishlist(WishDto wished);
        Task<ServiceResponse<WishlistDto>> RemoveSpecificWish(int wishedId);
    }
}