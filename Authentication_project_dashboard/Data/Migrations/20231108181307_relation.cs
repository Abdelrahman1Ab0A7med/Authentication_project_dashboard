using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication_project_dashboard.Data.Migrations
{
    public partial class relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__book_AspNetUsers_UserId",
                table: "_book");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "_book",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK__book_AspNetUsers_UserId",
                table: "_book",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__book_AspNetUsers_UserId",
                table: "_book");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "_book",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK__book_AspNetUsers_UserId",
                table: "_book",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
