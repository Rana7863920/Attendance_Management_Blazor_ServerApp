using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Data.Migrations
{
    public partial class changeFinancesIEnumerableInApplicationUserToFinanceAndAddSalaryPFPfAmountOvertimeColToMonthlySalaryTableFromFinance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "PF",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "PfAmount",
                table: "Finances");

            migrationBuilder.AddColumn<int>(
                name: "Overtime",
                table: "MonthlySalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PF",
                table: "MonthlySalaries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PfAmount",
                table: "MonthlySalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Overtime",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "PF",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "PfAmount",
                table: "MonthlySalaries");

            migrationBuilder.AddColumn<int>(
                name: "Overtime",
                table: "Finances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "PF",
                table: "Finances",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PfAmount",
                table: "Finances",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
