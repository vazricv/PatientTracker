using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatentTracker.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Completed",
                table: "PatientLogs",
                nullable: true,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "EnteredIn",
                table: "PatientLogs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_PatientLogs_PatientID",
                table: "PatientLogs",
                column: "PatientID");

            migrationBuilder.CreateIndex(
                name: "IX_PatientLogs_StageID",
                table: "PatientLogs",
                column: "StageID");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLogs_Patient_PatientID",
                table: "PatientLogs",
                column: "PatientID",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientLogs_Stage_StageID",
                table: "PatientLogs",
                column: "StageID",
                principalTable: "Stage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientLogs_Patient_PatientID",
                table: "PatientLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientLogs_Stage_StageID",
                table: "PatientLogs");

            migrationBuilder.DropIndex(
                name: "IX_PatientLogs_PatientID",
                table: "PatientLogs");

            migrationBuilder.DropIndex(
                name: "IX_PatientLogs_StageID",
                table: "PatientLogs");

            migrationBuilder.DropColumn(
                name: "Completed",
                table: "PatientLogs");

            migrationBuilder.DropColumn(
                name: "EnteredIn",
                table: "PatientLogs");
        }
    }
}
