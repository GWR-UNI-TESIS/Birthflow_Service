using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_columnas_de_auditoria_en_UsuarioEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                schema: "Auth",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                schema: "Auth",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                schema: "Auth",
                table: "Usuario",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "Auth",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "Auth",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "Auth",
                table: "Usuario");
        }
    }
}
