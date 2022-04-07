using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoveragePolygonService.Infraestructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteCoverages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteCoverages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Geopositions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    RouteCoverageId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Geopositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Geopositions_RouteCoverages_RouteCoverageId",
                        column: x => x.RouteCoverageId,
                        principalTable: "RouteCoverages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Geopositions_RouteCoverageId",
                table: "Geopositions",
                column: "RouteCoverageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Geopositions");

            migrationBuilder.DropTable(
                name: "RouteCoverages");
        }
    }
}
