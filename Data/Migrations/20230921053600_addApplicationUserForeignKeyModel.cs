using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorProject.Data.Migrations
{
    public partial class addApplicationUserForeignKeyModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "UserAttendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_UserAttendances_UserId",
                table: "UserAttendances",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAttendances_AspNetUsers_UserId",
                table: "UserAttendances",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAttendances_AspNetUsers_UserId",
                table: "UserAttendances");

            migrationBuilder.DropIndex(
                name: "IX_UserAttendances_UserId",
                table: "UserAttendances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAttendances");
        }
    }
}
