using Microsoft.EntityFrameworkCore.Migrations;

namespace YouthCareServer.Migrations
{
    public partial class UpdateAnalysisModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Measure",
                table: "Analysis",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "Analysis",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Weight",
                table: "Analysis",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Analysis");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Analysis");

            migrationBuilder.AlterColumn<double>(
                name: "Measure",
                table: "Analysis",
                type: "float",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);
        }
    }
}
