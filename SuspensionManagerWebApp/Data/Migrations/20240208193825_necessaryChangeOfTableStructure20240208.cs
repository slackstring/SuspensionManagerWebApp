using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class necessaryChangeOfTableStructure20240208 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirForkSettings");

            migrationBuilder.DropTable(
                name: "AirShockSettings");

            migrationBuilder.DropTable(
                name: "CoilShockSettings");

            migrationBuilder.AlterColumn<string>(
                name: "Stroke",
                table: "SusElements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModelYear",
                table: "SusElements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Length",
                table: "SusElements",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SusElementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Setting_SusElements_SusElementId",
                        column: x => x.SusElementId,
                        principalTable: "SusElements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Setting_SusElementId",
                table: "Setting",
                column: "SusElementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");

            migrationBuilder.AlterColumn<int>(
                name: "Stroke",
                table: "SusElements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ModelYear",
                table: "SusElements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Length",
                table: "SusElements",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AirForkSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NToken = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirForkSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirShockSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NNegToken = table.Column<int>(type: "int", nullable: false),
                    NPosToken = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirShockSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoilShockSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpringRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoilShockSettings", x => x.Id);
                });
        }
    }
}
