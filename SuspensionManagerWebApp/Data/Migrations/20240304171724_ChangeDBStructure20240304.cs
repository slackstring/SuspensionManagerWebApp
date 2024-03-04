using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class ChangeDBStructure20240304 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "ActiveSetting",
            //    table: "SusElements");

            migrationBuilder.AddColumn<string>(
                name: "AirForkSetting_AirPressure",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AirPressure",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoilForkSetting_PreloadTurns",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoilForkSetting_SpringRate",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NNegToken",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NPosToken",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NToken",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreloadTurns",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SettingType",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SpringRate",
                table: "Setting",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirForkSetting_AirPressure",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "AirPressure",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "CoilForkSetting_PreloadTurns",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "CoilForkSetting_SpringRate",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "NNegToken",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "NPosToken",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "NToken",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "PreloadTurns",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SettingType",
                table: "Setting");

            migrationBuilder.DropColumn(
                name: "SpringRate",
                table: "Setting");

            migrationBuilder.AddColumn<int>(
                name: "ActiveSetting",
                table: "SusElements",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
