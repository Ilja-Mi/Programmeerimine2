using System;
using System.ComponentModel.DataAnnotations;
using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Administrators
{
    public class SaveAdministratorCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public string Password { get; set; }
    }
}
