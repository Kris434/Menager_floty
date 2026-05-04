using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Branches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Car",
                newName: "BranchId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_UserId",
                table: "Car",
                newName: "IX_Car_BranchId");

            migrationBuilder.AddColumn<int>(
                name: "TrailerId",
                table: "TrailerAgregatInspections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Trailer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FuelLevel",
                table: "Trailer",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsBlocked",
                table: "Trailer",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchName = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Branches_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TrailerAgregatInspections_TrailerId",
                table: "TrailerAgregatInspections",
                column: "TrailerId");

            migrationBuilder.CreateIndex(
                name: "IX_Trailer_BranchId",
                table: "Trailer",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Branches_UserId",
                table: "Branches",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_Branches_BranchId",
                table: "Car",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Branches_BranchId",
                table: "Trailer",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrailerAgregatInspections_Trailer_TrailerId",
                table: "TrailerAgregatInspections",
                column: "TrailerId",
                principalTable: "Trailer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_Branches_BranchId",
                table: "Car");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Branches_BranchId",
                table: "Trailer");

            migrationBuilder.DropForeignKey(
                name: "FK_TrailerAgregatInspections_Trailer_TrailerId",
                table: "TrailerAgregatInspections");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropIndex(
                name: "IX_TrailerAgregatInspections_TrailerId",
                table: "TrailerAgregatInspections");

            migrationBuilder.DropIndex(
                name: "IX_Trailer_BranchId",
                table: "Trailer");

            migrationBuilder.DropColumn(
                name: "TrailerId",
                table: "TrailerAgregatInspections");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Trailer");

            migrationBuilder.DropColumn(
                name: "FuelLevel",
                table: "Trailer");

            migrationBuilder.DropColumn(
                name: "IsBlocked",
                table: "Trailer");

            migrationBuilder.RenameColumn(
                name: "BranchId",
                table: "Car",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Car_BranchId",
                table: "Car",
                newName: "IX_Car_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_UserId",
                table: "Car",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
