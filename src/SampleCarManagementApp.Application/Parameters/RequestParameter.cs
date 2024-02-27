using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Application.Parameters
{
    public record RequestParameter(int PageNumber = 1, int PageSize = 10);
}