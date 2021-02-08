using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ItemDtoResolver : IValueResolver<ItemDto, Item, string>
    {
        private readonly IConfiguration _configuration;

        public ItemDtoResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(ItemDto source, Item destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
           {
               return _configuration["ApiUrl"] + source.PictureUrl;
           }

           return null;
        }

        
    }
}