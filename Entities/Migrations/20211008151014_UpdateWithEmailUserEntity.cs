using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UpdateWithEmailUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "user",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "user",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "user",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "user",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
