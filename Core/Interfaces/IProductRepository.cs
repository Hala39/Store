using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Wrappers;
using Core.Dtos;
using Core.Helpers;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<PagedResponse<List<ProductToReturnDto>>> GetProductsAsync
        (   PaginationFilter filter,
            string orderBy, 
            string searchString, 
            int? categoryId,
            int? pageIndex
            );
        Task<ServiceResponse<ProductToReturnDto>> GetProductByIdAsync(int id);
     
    }
}