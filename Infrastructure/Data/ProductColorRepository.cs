using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Wrappers;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductColorRepository : IProductColorRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductColorRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProductColorDto>> GetProductColorByProductId(int id)
        {
            IQueryable<ProductColor> productsIQ = from pc in _context.ProductColors
            .Include(pc => pc.Color)
                select pc;

            productsIQ = productsIQ.Where(p => p.ProductId == id);
            var data = await productsIQ.AsTracking().ToListAsync();
            var mapped = data.Select(pc => _mapper.Map<ProductColorDto>(pc)).ToList();
            return mapped;
        }
    }
}