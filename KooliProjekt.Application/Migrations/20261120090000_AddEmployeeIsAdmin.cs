using Microsoft.EntityFrameworkCore.Migrations;
#nullable disable
namespace KooliProjekt.Application.Migrations
{
    public partial class AddEmployeeIsAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(name: "IsAdmin", table: "Employees", type: "bit", nullable: false, defaultValue: false);
            migrationBuilder.Sql("UPDATE [Employees] SET [IsAdmin] = 1 WHERE [Discriminator] = N'Administrator';");
        }
        protected override void Down(MigrationBuilder migrationBuilder)
            => migrationBuilder.DropColumn(name: "IsAdmin", table: "Employees");
    }
}
