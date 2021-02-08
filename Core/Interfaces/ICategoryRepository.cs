using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IReadOnlyList<Category>> GetCategoriesAsync();
    }
}