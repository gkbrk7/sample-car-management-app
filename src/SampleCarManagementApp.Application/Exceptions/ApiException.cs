using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using SampleCarManagementApp.Domain.Enums;

namespace SampleCarManagementApp.Application.Exceptions
{

    public class ApiException : Exception
    {
        public List<ExceptionType> Exceptions { get; set; } = [];
        public ApiException(IEnumerable<ExceptionType> exceptions, string message) : base(message)
        {
            Exceptions.AddRange(exceptions);
        }

    }
}