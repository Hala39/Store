using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class ProductColorUrlResolver : IValueResolver<ProductColor, ProductColorDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductColorUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(ProductColor source, ProductColorDto destination, string destMember, ResolutionContext context)
        {
           if(!string.IsNullOrEmpty(source.PictureUrl))
           {
               return _configuration["ApiUrl"] + source.PictureUrl;
           }

           return null;
        }
    }
}