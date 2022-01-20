using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW2.Migrations
{
    public partial class AddAppointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BicycleCompetition");

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BicycleId = table.Column<int>(type: "int", nullable: false),
                    CompetitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_Bicycles_BicycleId",
                        column: x => x.BicycleId,
                        principalTable: "Bicycles",
                        principalColumn: "BicycleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BicycleId",
                table: "Appointments",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompetitionId",
                table: "Appointments",
                column: "CompetitionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointments");

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
        }
    }
}
