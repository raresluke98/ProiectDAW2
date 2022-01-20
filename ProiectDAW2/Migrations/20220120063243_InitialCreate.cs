using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW2.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycles",
                columns: table => new
                {
                    BicycleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    FrameNumber = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycles", x => x.BicycleId);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompetitionName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Terrain = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Descriptions",
                columns: table => new
                {
                    DescriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    WheelSize = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BicycleType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    BicycleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptions", x => x.DescriptionId);
                    table.ForeignKey(
                        name: "FK_Descriptions_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentDate = table.Column<string>(type: "nvarchar(10)", nullable: true),
                    Operation = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Cost = table.Column<int>(type: "int", nullable: false),
                    BicycleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                    table.ForeignKey(
                        name: "FK_Services_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BicycleCompetition",
                columns: table => new
                {
                    BicyclesBicycleId = table.Column<int>(type: "int", nullable: false),
                    CompetitionsCompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleCompetition", x => new { x.BicyclesBicycleId, x.CompetitionsCompetitionId });
                    table.ForeignKey(
                        name: "FK_BicycleCompetition_Bicycles_BicyclesBicycleId",
                        column: x => x.BicyclesBicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BicycleCompetition_Competitions_CompetitionsCompetitionId",
                        column: x => x.CompetitionsCompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BicycleCompetition_CompetitionsCompetitionId",
                table: "BicycleCompetition",
                column: "CompetitionsCompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_BicycleId",
                table: "Descriptions",
                column: "BicycleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_BicycleId",
                table: "Services",
                column: "BicycleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BicycleCompetition");

            migrationBuilder.DropTable(
                name: "Descriptions");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Bicycles");
        }
    }
}
