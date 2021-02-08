using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Dtos;
using Core.Wrappers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using Core;
using Microsoft.AspNetCore.Mvc;
using Core.Helpers;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public string PriceSort { get; set; }
        public int? CurrentFilter { get; set; } 

        public async Task<ServiceResponse<ProductToReturnDto>> GetProductByIdAsync(int id)
        {
            ServiceResponse<ProductToReturnDto> response = new ServiceResponse<ProductToReturnDto>();
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);
            if(product == null)
            {
                response.Success = false;
                response.Message = "Product Not Found!";
                return response;
            }
            response.Data = _mapper.Map<ProductToReturnDto>(product);

            return response;
        }

        public async Task<PagedResponse<List<ProductToReturnDto>>> GetProductsAsync
        (
            [FromQuery] PaginationFilter filter,
            string orderBy, 
            string searchString, 
            int? categoryId,
            int? pageIndex
        )
        {    

            IQueryable<Product> productsIQ = from p in _context.Products
            .Include(p => p.Category)
                select p;
            
            if (searchString != null)
            {
                pageIndex = 1;
            }

             if (categoryId != null)
            {
                productsIQ = productsIQ.Where(p => p.CategoryId == categoryId);
            }
          
            if (!String.IsNullOrEmpty(searchString))
            {
                productsIQ = productsIQ.Where(p => p.Description.ToLower().Contains(searchString.ToLower())
                                                || p.Category.Name.ToLower().Contains(searchString.ToLower()));
            }

            if(!String.IsNullOrEmpty(orderBy))
            {
                switch (orderBy)
                {
                    case "price_desc":
                        productsIQ = productsIQ.OrderByDescending(p => p.Price);
                        break;
                    case "price":
                        productsIQ = productsIQ.OrderBy(p => p.Price);
                        break;
                    default:
                        productsIQ = productsIQ.OrderByDescending(p => p.EntryYear).ThenBy(p => p.EntryMonth).ThenBy(p => p.EntryDay);
                        break;
                }
            }

            var validFilter = new PaginationFilter(filter.PageIndex, filter.PageSize);

            var pagedData = await productsIQ.AsTracking()
                .Skip((validFilter.PageIndex - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var mapped = pagedData.Select(p => _mapper.Map<ProductToReturnDto>(p)).ToList();  
            var totalRecords = await productsIQ.AsTracking().CountAsync();
            var pagedResponse = PaginationHelper.CreatePagedResponse<ProductToReturnDto>(mapped, validFilter, totalRecords);
            return pagedResponse;
        }

    }
}