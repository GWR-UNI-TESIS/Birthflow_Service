using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Reparando_IdUsuario_Passwords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_User_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_Password_UserId",
                schema: "Auth",
                table: "Password",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_User_UserId",
                schema: "Auth",
                table: "Password",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_User_UserId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropIndex(
                name: "IX_Password_UserId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                schema: "Auth",
                table: "Password",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 19, 35, 29, 333, DateTimeKind.Local).AddTicks(3005), new Guid("1276946c-fa84-487e-82ea-4ccb8741ba4e") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 19, 35, 29, 333, DateTimeKind.Local).AddTicks(3017), new Guid("188e39c0-a47d-49f3-816d-b60a86d253f7") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 19, 35, 29, 333, DateTimeKind.Local).AddTicks(3018), new Guid("5fbe22eb-b2f8-4316-b29b-b5c5551f037d") });

            migrationBuilder.CreateIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_User_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
