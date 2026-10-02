using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        public ICollection<Operation> Operations { get; set; }
            = new List<Operation>();

        public void Login()
        {
        }

        public ICollection<Operation> ViewOperations()
        {
            return Operations;
        }

        public void ChangeStatus(Operation operation, Status status)
        {
            operation.ChangeStatus(status);
        }
    }
}
