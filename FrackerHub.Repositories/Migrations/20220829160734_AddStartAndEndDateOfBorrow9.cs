using Microsoft.EntityFrameworkCore.Migrations;

namespace FrackerHub.Repositories.Migrations
{
    public partial class AddStartAndEndDateOfBorrow9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDateOfBirth",
                table: "UserItems",
                newName: "EndDateOfBorrow");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EndDateOfBorrow",
                table: "UserItems",
                newName: "EndDateOfBirth");
        }
    }
}
