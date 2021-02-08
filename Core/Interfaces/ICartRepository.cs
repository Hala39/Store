using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface ICartRepository
    {
        Task<ServiceResponse<CartDto>> GetCart();
        Task<ServiceResponse<CartDto>> EmptyCart();
        Task<ServiceResponse<CartDto>> AddToCart(ItemDto item);
        Task<ServiceResponse<CartDto>> RemoveSpecificItem(int itemId);
        Task<ServiceResponse<CartDto>> UpdateItemInCart(ItemDto specificItem);

    }
}