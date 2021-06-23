using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MessageRead",
                table: "Message",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "RecepientDeleted",
                table: "Message",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SenderDeleted",
                table: "Message",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "AnalysisDetection",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SportsmanId = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false),
                    AnalysisType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisDetection", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisDetection");

            migrationBuilder.DropColumn(
                name: "MessageRead",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "RecepientDeleted",
                table: "Message");

            migrationBuilder.DropColumn(
                name: "SenderDeleted",
                table: "Message");
        }
    }
}
