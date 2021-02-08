using System;
using System.Collections.Generic;

namespace Core.Wrappers
{
    public class PagedResponse<T> : ServiceResponse<T>
    {
         public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.Data = data;
            this.Message = null;
        }
    }
}