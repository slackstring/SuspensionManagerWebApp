using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class AddedUserID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CoilShockSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AirShockSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AirForkSettings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoilShockSettings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AirShockSettings");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AirForkSettings");
        }
    }
}
