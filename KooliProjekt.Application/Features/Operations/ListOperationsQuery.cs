using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Operations
{
    public class ListOperationsQuery : IRequest<IEnumerable<Operation>>
    {
    }
}
