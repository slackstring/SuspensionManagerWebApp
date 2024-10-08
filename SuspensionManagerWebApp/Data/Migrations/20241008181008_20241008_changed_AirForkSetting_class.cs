using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class _20241008_changed_AirForkSetting_class : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setting_SusElements_SusElementId",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "SusElementId",
                table: "Setting",
                newName: "SusElementID");

            migrationBuilder.RenameColumn(
                name: "NToken",
                table: "Setting",
                newName: "AirForkSetting_NPosToken");

            migrationBuilder.RenameIndex(
                name: "IX_Setting_SusElementId",
                table: "Setting",
                newName: "IX_Setting_SusElementID");

            migrationBuilder.AlterColumn<int>(
                name: "SusElementID",
                table: "Setting",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Setting_SusElements_SusElementID",
                table: "Setting",
                column: "SusElementID",
                principalTable: "SusElements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Setting_SusElements_SusElementID",
                table: "Setting");

            migrationBuilder.RenameColumn(
                name: "SusElementID",
                table: "Setting",
                newName: "SusElementId");

            migrationBuilder.RenameColumn(
                name: "AirForkSetting_NPosToken",
                table: "Setting",
                newName: "NToken");

            migrationBuilder.RenameIndex(
                name: "IX_Setting_SusElementID",
                table: "Setting",
                newName: "IX_Setting_SusElementId");

            migrationBuilder.AlterColumn<int>(
                name: "SusElementId",
                table: "Setting",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Setting_SusElements_SusElementId",
                table: "Setting",
                column: "SusElementId",
                principalTable: "SusElements",
                principalColumn: "Id");
        }
    }
}
