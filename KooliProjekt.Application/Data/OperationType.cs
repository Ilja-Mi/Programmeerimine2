using Azure;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class OperationType
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public ICollection<Operation> Operations { get; set; }
            = new List<Operation>();

        public void AddType()
        {
        }

        public void UpdateType()
        {
        }

        public void DeleteType()
        {
        }
    }
}
