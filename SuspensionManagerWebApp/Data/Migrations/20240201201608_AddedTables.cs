using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SuspensionManagerWebApp.Data.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AirForkSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NToken = table.Column<int>(type: "int", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AirPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NPosToken = table.Column<int>(type: "int", nullable: false),
                    NNegToken = table.Column<int>(type: "int", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpringRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LSR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HSR = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoilShockSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SusElements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelYear = table.Column<int>(type: "int", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Stroke = table.Column<int>(type: "int", nullable: false),
                    SuspensionTyp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SusElements", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AirForkSettings");

            migrationBuilder.DropTable(
                name: "AirShockSettings");

            migrationBuilder.DropTable(
                name: "CoilShockSettings");

            migrationBuilder.DropTable(
                name: "SusElements");
        }
    }
}
