using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Data.Migrations
{
    public partial class moveBackPFboolColToFinanceFromMonthlySalary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PF",
                table: "MonthlySalaries");

            migrationBuilder.AddColumn<bool>(
                name: "PF",
                table: "Finances",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PF",
                table: "Finances");

            migrationBuilder.AddColumn<bool>(
                name: "PF",
                table: "MonthlySalaries",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
