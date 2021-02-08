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
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductSizeRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IReadOnlyList<ProductSizeDto>> GetProductSizesByProductId(int id)
        {
            IQueryable<ProductSize> productIQ = from ps in _context.ProductSizes
            .Include(pc => pc.Size)
                select ps;

            productIQ = productIQ.Where(ps => ps.ProductId == id);
            var data = await productIQ.AsTracking().ToListAsync();
            var mapped = data.Select(ps => _mapper.Map<ProductSizeDto>(ps)).ToList();
            return mapped;
                
        }
    }
}