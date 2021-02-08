using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Wrappers;

namespace Core.Interfaces
{
    public interface IProductSizeRepository
    {
        Task<IReadOnlyList<ProductSizeDto>> GetProductSizesByProductId(int id);
    }
}