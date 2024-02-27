using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Domain.Entities
{
    public abstract class BaseEntity
    {
        public required int Id { get; set; }
    }
}