using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Wrappers;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories
                .ToListAsync();
            
        }
    }
}