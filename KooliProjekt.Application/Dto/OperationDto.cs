using System;
using KooliProjekt.Application.Data;

namespace KooliProjekt.Application.Dto
{
    public class OperationDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Status Status { get; set; }
        public decimal? Cost { get; set; }
        public int CarId { get; set; }
        public string LicensePlate { get; set; }
        public int OperationTypeId { get; set; }
        public string OperationTypeName { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string OperationTypeDescription { get; set; }
    }
}
