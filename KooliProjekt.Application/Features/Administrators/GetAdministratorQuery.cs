using KooliProjekt.Application.Data;
using MediatR;

namespace KooliProjekt.Application.Features.Administrators
{
    public class GetAdministratorQuery : IRequest<Administrator>
    {
        public int Id { get; set; }
    }
}
