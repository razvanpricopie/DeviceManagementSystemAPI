using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class AddUserDeviceRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "device",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_device_UserId",
                table: "device",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_device_user_UserId",
                table: "device",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_user_UserId",
                table: "device");

            migrationBuilder.DropIndex(
                name: "IX_device_UserId",
                table: "device");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "device");
        }
    }
}
