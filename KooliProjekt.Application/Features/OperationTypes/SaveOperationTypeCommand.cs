using System;
using System.ComponentModel.DataAnnotations;
using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class SaveOperationTypeCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }
    }
}
