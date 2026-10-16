using System.Collections.Generic;
using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Administrators
{
    public class ListAdministratorsQuery : IRequest<IEnumerable<Administrator>>
    {
    }
}
