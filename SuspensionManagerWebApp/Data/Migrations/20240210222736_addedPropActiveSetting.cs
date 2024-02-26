using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class addedPropActiveSetting : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActiveSettingId",
                table: "SusElements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SusElements_ActiveSettingId",
                table: "SusElements",
                column: "ActiveSettingId");

            migrationBuilder.AddForeignKey(
                name: "FK_SusElements_Setting_ActiveSettingId",
                table: "SusElements",
                column: "ActiveSettingId",
                principalTable: "Setting",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SusElements_Setting_ActiveSettingId",
                table: "SusElements");

            migrationBuilder.DropIndex(
                name: "IX_SusElements_ActiveSettingId",
                table: "SusElements");

            migrationBuilder.DropColumn(
                name: "ActiveSettingId",
                table: "SusElements");
        }
    }
}
