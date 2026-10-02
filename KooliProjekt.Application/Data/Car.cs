using Azure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Manufacturer { get; set; }

        [Required]
        [StringLength(100)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string LicensePlate { get; set; }

        public ICollection<Operation> Operations { get; set; }
            = new List<Operation>();

        public void AddOperation(Operation operation)
        {
            Operations.Add(operation);
        }

        public ICollection<Operation> ViewOperations()
        {
            return Operations;
        }
    }
}