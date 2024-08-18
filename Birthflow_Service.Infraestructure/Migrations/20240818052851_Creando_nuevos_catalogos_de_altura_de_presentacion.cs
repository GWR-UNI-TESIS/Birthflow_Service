using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Creando_nuevos_catalogos_de_altura_de_presentacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Position",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "HodgePlanes",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HodgePlanes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Partograph",
                table: "HodgePlanes",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "OP", "Occipito Posterior" },
                    { 2, "OIIA", "Occipito Izquierda Anterior" },
                    { 3, "OIIT", "Occipito Izquierda Transversa" },
                    { 4, "OIIP", "Occipito Izquierda Posterior" },
                    { 5, "OS", "Occipito Sacro" },
                    { 6, "OIDA", "Occipito Derecha Anterior" },
                    { 7, "OIDT", "Occipito Derecha Transversa" },
                    { 8, "OIDP", "Occipito Derecha Posterior" }
                });

            migrationBuilder.InsertData(
                schema: "Partograph",
                table: "Positions",
                columns: new[] { "Id", "Code", "Description" },
                values: new object[,]
                {
                    { 1, " I", "Plano I" },
                    { 2, "II", "Plano II" },
                    { 3, "III", "Plano III" },
                    { 4, "IV", "Plano IV" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresentationPositionVariety_HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                column: "HodgePlane");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationPositionVariety_Position",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                column: "Position");

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationPositionVariety_HodgePlanes_HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                column: "HodgePlane",
                principalSchema: "Partograph",
                principalTable: "HodgePlanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresentationPositionVariety_Positions_Position",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                column: "Position",
                principalSchema: "Partograph",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresentationPositionVariety_HodgePlanes_HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety");

            migrationBuilder.DropForeignKey(
                name: "FK_PresentationPositionVariety_Positions_Position",
                schema: "Partograph",
                table: "PresentationPositionVariety");

            migrationBuilder.DropTable(
                name: "HodgePlanes",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "Positions",
                schema: "Partograph");

            migrationBuilder.DropIndex(
                name: "IX_PresentationPositionVariety_HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety");

            migrationBuilder.DropIndex(
                name: "IX_PresentationPositionVariety_Position",
                schema: "Partograph",
                table: "PresentationPositionVariety");

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "HodgePlane",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
