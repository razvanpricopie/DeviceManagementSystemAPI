using Microsoft.EntityFrameworkCore.Migrations;

namespace Entities.Migrations
{
    public partial class UpdateUserDeviceRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_user_UserId",
                table: "device");

            migrationBuilder.DropIndex(
                name: "IX_device_UserId",
                table: "device");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "device",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_device_UserId",
                table: "device",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_device_user_UserId",
                table: "device",
                column: "UserId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_device_user_UserId",
                table: "device");

            migrationBuilder.DropIndex(
                name: "IX_device_UserId",
                table: "device");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "device",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
