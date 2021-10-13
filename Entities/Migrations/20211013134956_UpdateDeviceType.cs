using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UpdateDeviceType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Type",
                table: "device",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "device",
                type: "nvarchar(60)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
