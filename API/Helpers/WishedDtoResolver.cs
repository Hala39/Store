using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class WishDtoResolver : IValueResolver<WishDto, Wish, string>
    {
        private readonly IConfiguration _configuration;

        public WishDtoResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(WishDto source, Wish destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
           {
               return _configuration["ApiUrl"] + source.PictureUrl;
           }

           return null;
        }

        
    }
}