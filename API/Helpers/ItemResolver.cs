using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ItemResolver : IValueResolver<Item, ItemDto, string>
    {
        private readonly IConfiguration _configuration;

        public ItemResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Item source, ItemDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
           {
               return _configuration["ApiUrl"] + source.PictureUrl;
           }

           return null;
        }
    }
}