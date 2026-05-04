using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class TrailersUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trailer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Capacity = table.Column<int>(type: "integer", nullable: false),
                    Plate = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trailer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrailerInspection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DateOfInpection = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValidUntil = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrailerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrailerInspection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrailerInspection_Trailer_TrailerId",
                        column: x => x.TrailerId,
                        principalTable: "Trailer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrailerInspection_TrailerId",
                table: "TrailerInspection",
                column: "TrailerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrailerInspection");

            migrationBuilder.DropTable(
                name: "Trailer");
        }
    }
}
