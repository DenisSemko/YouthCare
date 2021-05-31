using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateModelWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ParentIdId = table.Column<Guid>(nullable: true),
                    ChildIdId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersUsers_AspNetUsers_ChildIdId",
                        column: x => x.ChildIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersUsers_AspNetUsers_ParentIdId",
                        column: x => x.ParentIdId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UsersUsers_ChildIdId",
                table: "UsersUsers",
                column: "ChildIdId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersUsers_ParentIdId",
                table: "UsersUsers",
                column: "ParentIdId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersUsers");
        }
    }
}
