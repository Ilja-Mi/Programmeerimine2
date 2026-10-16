using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class GetOperationTypeQuery : IRequest<OperationType>
    {
        public int Id { get; set; }
    }
}
