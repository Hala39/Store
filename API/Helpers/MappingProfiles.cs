using System.Linq;
using AutoMapper;
using Core.Dtos;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(d => d.Category, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductUrlResolver>());
            CreateMap<ProductColor, ProductColorDto>()
                .ForMember(d => d.ColorName, o => o.MapFrom(pc => pc.Color.Name))
                .ForMember(d => d.ColorId, o => o.MapFrom(pc => pc.Color.Id))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductColorUrlResolver>());
            CreateMap<ProductSize, ProductSizeDto>()
                .ForMember(d => d.SizeName, o => o.MapFrom(ps => ps.Size.Name))
                .ForMember(d => d.SizeId, o => o.MapFrom(ps => ps.Size.Id));
            CreateMap<Item, ItemDto>();
            CreateMap<ItemDto, Item>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ItemDtoResolver>());
            CreateMap<Cart, CartDto>();
            CreateMap<CartDto, Cart>();
            CreateMap<Wish, WishDto>();
            CreateMap<WishDto, Wish>()
                .ForMember(d => d.PictureUrl, o => o.MapFrom<WishDtoResolver>());
            CreateMap<Wishlist, WishlistDto>();
            CreateMap<WishlistDto, Wishlist>();
            
        }

    }
}