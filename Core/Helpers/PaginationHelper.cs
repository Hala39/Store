using System.Collections.Generic;
using Core.Wrappers;
using System;
using System.Linq;

namespace Core.Helpers
{
    public static class PaginationHelper
    {
        public static PagedResponse<List<T>> CreatePagedResponse<T>(List<T> pagedData, PaginationFilter validFilter,int totalRecords)
        {
            var response = new PagedResponse<List<T>>(pagedData, validFilter.PageIndex, validFilter.PageSize);
            var totalPages = ((double)totalRecords / (double)validFilter.PageSize);
            int roundedTotalPages = Convert.ToInt32(Math.Ceiling(totalPages)); 
            response.TotalPages = roundedTotalPages;
            response.TotalRecords = totalRecords;
            return response;
        }
    }
}