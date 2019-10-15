using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatentTracker.Migrations
{
    public partial class addingDueTime4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueTime",
                table: "Stage",
                nullable: false,
                oldClrType: typeof(float));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "DueTime",
                table: "Stage",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
