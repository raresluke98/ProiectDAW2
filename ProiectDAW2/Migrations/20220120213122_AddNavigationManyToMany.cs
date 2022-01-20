using Microsoft.EntityFrameworkCore.Migrations;

namespace ProiectDAW2.Migrations
{
    public partial class AddNavigationManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Services_BicycleId",
                table: "Services",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_BicycleId",
                table: "Descriptions",
                column: "BicycleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BicycleId",
                table: "Appointments",
                column: "BicycleId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CompetitionId",
                table: "Appointments",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Bicycles_BicycleId",
                table: "Appointments",
                column: "BicycleId",
                principalTable: "Bicycles",
                principalColumn: "BicycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Competitions_CompetitionId",
                table: "Appointments",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "CompetitionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Bicycles_BicycleId",
                table: "Descriptions",
                column: "BicycleId",
                principalTable: "Bicycles",
                principalColumn: "BicycleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Bicycles_BicycleId",
                table: "Services",
                column: "BicycleId",
                principalTable: "Bicycles",
                principalColumn: "BicycleId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Bicycles_BicycleId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Competitions_CompetitionId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Bicycles_BicycleId",
                table: "Descriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Bicycles_BicycleId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_BicycleId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_BicycleId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BicycleId",
                table: "Appointments");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_CompetitionId",
                table: "Appointments");
        }
    }
}
