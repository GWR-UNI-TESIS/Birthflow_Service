using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cambiando_el_tipo_de_id_de_usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                schema: "Auth",
                table: "Usuario",
                type: "decimal(8,0)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.DropIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropForeignKey(
                name: "FK_Password_Usuario_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                schema: "Auth",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Auth",
                table: "Usuario");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                schema: "Auth",
                table: "Usuario",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()"
            );

            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                schema: "Auth",
                table: "Password",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                schema: "Auth",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_Usuario_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId",
                principalSchema: "Auth",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_Usuario_UsuarioId1",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropIndex(
                name: "IX_Password_UsuarioId1",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                schema: "Auth",
                table: "Password");

            migrationBuilder.AlterColumn<decimal>(
                name: "PhoneNumber",
                schema: "Auth",
                table: "Usuario",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(8,0)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Auth",
                table: "Usuario",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_Usuario_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId",
                principalSchema: "Auth",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
