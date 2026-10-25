using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public IList<OperationListItemDto> Operations { get; set; } = new List<OperationListItemDto>();
    }
}
