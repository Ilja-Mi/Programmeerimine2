using KooliProjekt.Application.Dto;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypeQuery : IRequest<OperationResult<OperationTypeDto>>
    {
        public int Id { get; set; }
    }
}
