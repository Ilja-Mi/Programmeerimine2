using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.OperationTypes
{
    public class ListOperationTypesQuery : IRequest<IEnumerable<OperationType>>
    {
    }
}
