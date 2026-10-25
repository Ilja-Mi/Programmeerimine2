using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Administrators
{
    public class GetAdministratorQuery : IRequest<OperationResult<AdministratorDto>>
    {
        public int Id { get; set; }
    }
}
