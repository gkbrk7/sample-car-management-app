using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleCarManagementApp.Domain.Entities
{
    public class Vehicle : BaseEntity
    {
        public required string Make { get; set; }
        public required string Model { get; set; }
        public string? ModelVersion { get; set; }
        public string? Color { get; set; }
        public int? Weight { get; set; }
        public string? RegistrationNumber { get; set; }
        public int? NumberOfDoors { get; set; }
        public DateOnly? ConstructionDate { get; set; }
        public string? BodyType { get; set; }
        public string? GearBox { get; set; }
    }
}