using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class OperationTypeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<OperationListItemDto> Operations { get; set; } = new List<OperationListItemDto>();
    }
}
