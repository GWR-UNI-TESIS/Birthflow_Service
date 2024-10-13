using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_Device_refreshtoken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Device",
                schema: "Auth",
                table: "RefreshToken",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 13, 3, 5, 16, 961, DateTimeKind.Utc).AddTicks(3040), new Guid("d904dafe-5e4d-42a7-84c9-9854ab15c5d3") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 13, 3, 5, 16, 961, DateTimeKind.Utc).AddTicks(3043), new Guid("380a24c4-e63d-4710-b7e4-418851db4971") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 13, 3, 5, 16, 961, DateTimeKind.Utc).AddTicks(3045), new Guid("19c4e9ba-f57f-4b90-98ef-b281839cabeb") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Device",
                schema: "Auth",
                table: "RefreshToken");

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
    }
}
