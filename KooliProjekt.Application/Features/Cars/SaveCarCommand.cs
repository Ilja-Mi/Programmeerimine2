using System;
using System.ComponentModel.DataAnnotations;
using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Cars
{
    public class SaveCarCommand : IRequest<OperationResult>, ITransactional
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
    }
}
