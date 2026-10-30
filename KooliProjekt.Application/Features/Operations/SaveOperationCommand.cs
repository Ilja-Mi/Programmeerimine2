using System;
using System.ComponentModel.DataAnnotations;
using KooliProjekt.Application.Data;
using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class SaveOperationCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Status Status { get; set; }

        public decimal? Cost { get; set; }

        public int CarId { get; set; }

        public int OperationTypeId { get; set; }

        public int? EmployeeId { get; set; }
    }
}
