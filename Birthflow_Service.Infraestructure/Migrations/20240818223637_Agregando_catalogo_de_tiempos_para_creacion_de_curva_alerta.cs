using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_catalogo_de_tiempos_para_creacion_de_curva_alerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkTime",
                schema: "Partograph",
                table: "Partographs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "WorkTime",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Paridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Posicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Membrana = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTime", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Partograph",
                table: "WorkTime",
                columns: new[] { "Id", "Membrana", "Paridad", "Posicion" },
                values: new object[,]
                {
                    { "HMI", "Integras", "Multiparas", "Horizontal" },
                    { "HMR", "Rotas", "Multiparas", "Horizontal" },
                    { "HNI", "Integras", "Nuliparas", "Horizontal" },
                    { "HNR", "Rotas", "Nuliparas", "Horizontal" },
                    { "VTI", "Integras", "Todas", "Vertical" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partographs_WorkTime",
                schema: "Partograph",
                table: "Partographs",
                column: "WorkTime");

            migrationBuilder.AddForeignKey(
                name: "FK_Partographs_WorkTime_WorkTime",
                schema: "Partograph",
                table: "Partographs",
                column: "WorkTime",
                principalSchema: "Partograph",
                principalTable: "WorkTime",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Partographs_WorkTime_WorkTime",
                schema: "Partograph",
                table: "Partographs");

            migrationBuilder.DropTable(
                name: "WorkTime",
                schema: "Partograph");

            migrationBuilder.DropIndex(
                name: "IX_Partographs_WorkTime",
                schema: "Partograph",
                table: "Partographs");

            migrationBuilder.AlterColumn<string>(
                name: "WorkTime",
                schema: "Partograph",
                table: "Partographs",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);
        }
    }
}
