using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Data.Migrations
{
    public partial class addApplicationUserForeignKeyToFinanceTableAndRemoveFinanceTableForeignKeyFromApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Finances_FinanceId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_FinanceId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FinanceId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Finances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Finances_ApplicationUserId",
                table: "Finances",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Finances_AspNetUsers_ApplicationUserId",
                table: "Finances",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Finances_AspNetUsers_ApplicationUserId",
                table: "Finances");

            migrationBuilder.DropIndex(
                name: "IX_Finances_ApplicationUserId",
                table: "Finances");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Finances");

            migrationBuilder.AddColumn<int>(
                name: "FinanceId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_FinanceId",
                table: "AspNetUsers",
                column: "FinanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Finances_FinanceId",
                table: "AspNetUsers",
                column: "FinanceId",
                principalTable: "Finances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
