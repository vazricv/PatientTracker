using Microsoft.EntityFrameworkCore.Migrations;

namespace PatentTracker.Migrations
{
    public partial class addingDueTime3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "DueTime",
                table: "Stage",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "DueTime",
                table: "Stage",
                nullable: false,
                oldClrType: typeof(float));
        }
    }
}
