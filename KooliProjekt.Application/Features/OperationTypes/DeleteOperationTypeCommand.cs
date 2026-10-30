using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class DeleteOperationTypeCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
