using System.Collections.Generic;

namespace KooliProjekt.Application.Dto
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicensePlate { get; set; }
        public IList<OperationListItemDto> Operations { get; set; } = new List<OperationListItemDto>();
    }
}
