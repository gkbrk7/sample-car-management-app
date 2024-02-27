using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; } = [];
        public ValidationException(IEnumerable<string> errors) : base("One or more validation failures have occured.")
        {
            Errors.AddRange(errors);
        }
    }
}