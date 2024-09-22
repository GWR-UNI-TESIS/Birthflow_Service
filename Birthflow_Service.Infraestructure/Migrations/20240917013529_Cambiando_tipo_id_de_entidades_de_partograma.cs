using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cambiando_tipo_id_de_entidades_de_partograma : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7291), new Guid("6bd0f20d-a57d-455e-996f-18b0023de7c9") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7310), new Guid("798a7a44-2a16-463c-bd6d-30c321b3021e") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7312), new Guid("ba43f5bb-7e45-47a3-bea1-c22ded8519ba") });
        }
    }
}
