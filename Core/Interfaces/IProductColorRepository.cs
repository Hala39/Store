using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface IProductColorRepository
    {
         
        Task<IReadOnlyList<ProductColorDto>> GetProductColorByProductId(int id);
         
    }
}