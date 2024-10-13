using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_propiedad_usersessionhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivity",
                schema: "Auth",
                table: "UserSessionHistory",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 12, 12, 10, 34, 542, DateTimeKind.Local).AddTicks(5928), new Guid("4986b47b-63e9-4ec9-9c78-800311d59694") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 12, 12, 10, 34, 542, DateTimeKind.Local).AddTicks(5941), new Guid("a8e74118-f3e8-4dbc-ba00-ccb0d1e765c9") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 12, 12, 10, 34, 542, DateTimeKind.Local).AddTicks(5942), new Guid("5fd502ec-6303-4ff7-b315-ad050f5568fe") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastActivity",
                schema: "Auth",
                table: "UserSessionHistory");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 6, 21, 16, 1, 161, DateTimeKind.Local).AddTicks(9595), new Guid("f747771a-3d12-4a60-8c97-2c8890bee22f") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 6, 21, 16, 1, 161, DateTimeKind.Local).AddTicks(9609), new Guid("fe19d9d7-7b83-4f78-bc23-aee5b06ab5cf") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 6, 21, 16, 1, 161, DateTimeKind.Local).AddTicks(9611), new Guid("e9af054a-67a1-4fe9-9e1d-d62dcc579b5c") });
        }
    }
}
