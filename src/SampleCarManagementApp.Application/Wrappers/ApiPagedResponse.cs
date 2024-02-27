using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Application.Wrappers
{
    public class ApiPagedResponse<T> : ApiResponse<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public static ApiPagedResponse<T> PagedFail(string message, int pageNumber, int pageSize)
        {
            return new ApiPagedResponse<T> { Message = message, Succeeded = false, PageNumber = pageNumber, PageSize = pageSize };
        }

        public static ApiPagedResponse<T> PagedSuccess(T data, int pageNumber, int pageSize, string? message = null)
        {
            return new ApiPagedResponse<T> { Data = data, Message = message, Succeeded = true, PageNumber = pageNumber, PageSize = pageSize };
        }
    }
}