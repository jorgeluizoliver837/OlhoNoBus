using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlhoNoBus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusLine",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLine", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusStop",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    BusLineId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusStop_BusLine_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusLineId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicle_BusLine_BusLineId",
                        column: x => x.BusLineId,
                        principalTable: "BusLine",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VehiclePosition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    VehicleId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclePosition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehiclePosition_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusStop_BusLineId",
                table: "BusStop",
                column: "BusLineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_BusLineId",
                table: "Vehicle",
                column: "BusLineId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclePosition_VehicleId",
                table: "VehiclePosition",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStop");

            migrationBuilder.DropTable(
                name: "VehiclePosition");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "BusLine");
        }
    }
}
