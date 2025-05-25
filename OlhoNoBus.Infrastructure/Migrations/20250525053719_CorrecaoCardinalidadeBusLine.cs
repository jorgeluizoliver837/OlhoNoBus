using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OlhoNoBus.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrecaoCardinalidadeBusLine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusStop_BusLine_BusLineId",
                table: "BusStop");

            migrationBuilder.DropIndex(
                name: "IX_BusStop_BusLineId",
                table: "BusStop");

            migrationBuilder.DropColumn(
                name: "BusLineId",
                table: "BusStop");

            migrationBuilder.CreateTable(
                name: "BusLineBusStop",
                columns: table => new
                {
                    BusLinesId = table.Column<long>(type: "bigint", nullable: false),
                    BusStopsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLineBusStop", x => new { x.BusLinesId, x.BusStopsId });
                    table.ForeignKey(
                        name: "FK_BusLineBusStop_BusLine_BusLinesId",
                        column: x => x.BusLinesId,
                        principalTable: "BusLine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusLineBusStop_BusStop_BusStopsId",
                        column: x => x.BusStopsId,
                        principalTable: "BusStop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusLineBusStop_BusStopsId",
                table: "BusLineBusStop",
                column: "BusStopsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusLineBusStop");

            migrationBuilder.AddColumn<long>(
                name: "BusLineId",
                table: "BusStop",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusStop_BusLineId",
                table: "BusStop",
                column: "BusLineId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusStop_BusLine_BusLineId",
                table: "BusStop",
                column: "BusLineId",
                principalTable: "BusLine",
                principalColumn: "Id");
        }
    }
}
