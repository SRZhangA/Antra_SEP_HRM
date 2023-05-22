using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnBoarding.API.Migrations
{
    /// <inheritdoc />
    public partial class TypoFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeIdeneityId",
                table: "Employees",
                newName: "EmployeeIdentityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeIdentityId",
                table: "Employees",
                newName: "EmployeeIdeneityId");
        }
    }
}
