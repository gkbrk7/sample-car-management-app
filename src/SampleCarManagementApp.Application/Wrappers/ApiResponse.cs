using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.Application.Wrappers
{
    public class ApiResponse<T>
    {
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public T? Data { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public string? Message { get; set; }

        public bool Succeeded { get; set; }
        public IEnumerable<ExceptionType> ErrorTypes { get; set; } = [];
        public IEnumerable<string> Errors { get; set; } = [];

        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T> { Message = message, Succeeded = false };
        }

        public static ApiResponse<T> Success(T data, string? message = null)
        {
            return new ApiResponse<T> { Data = data, Message = message, Succeeded = true };
        }

    }
}