using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class GetOperationQuery : IRequest<Operation>
    {
        public int Id { get; set; }
    }
}
