using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class addedPropActiveSettingpropActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Setting",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Setting");
        }
    }
}
