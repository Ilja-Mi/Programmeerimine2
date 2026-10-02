using System;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Application.Data
{
    public class Operation
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public Status Status { get; set; }

        public decimal? Cost { get; set; }


        public int CarId { get; set; }
        public Car Car { get; set; }

        public int OperationTypeId { get; set; }
        public OperationType OperationType { get; set; }


        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public void ChangeStatus(Status status)
        {
            Status = status;
        }

        public void AssignEmployee(Employee employee)
        {
            Employee = employee;
            EmployeeId = employee.Id;
        }
    }
}
