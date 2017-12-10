using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace NetNote.Migrations
{
    public partial class NotePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Attachment",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Notes",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NoteModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Content = table.Column<string>(nullable: false),
                    Tile = table.Column<string>(maxLength: 1000, nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteModel", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NoteModel");

            migrationBuilder.DropColumn(
                name: "Attachment",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Notes");
        }
    }
}
