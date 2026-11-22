namespace KooliProjekt.Application.Dto
{
    public class EmployeeListItemDto
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int OperationCount { get; set; }
    }
}
