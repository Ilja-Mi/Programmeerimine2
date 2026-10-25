using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationQuery : IRequest<OperationResult<OperationDto>>
    {
        public int Id { get; set; }
    }
}
