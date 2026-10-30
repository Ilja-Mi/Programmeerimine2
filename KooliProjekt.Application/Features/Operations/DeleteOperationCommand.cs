using KooliProjekt.Application.Behaviors;
using KooliProjekt.Application.Infrastructure.Results;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class DeleteOperationCommand : IRequest<OperationResult>, ITransactional
    {
        public int Id { get; set; }
    }
}
