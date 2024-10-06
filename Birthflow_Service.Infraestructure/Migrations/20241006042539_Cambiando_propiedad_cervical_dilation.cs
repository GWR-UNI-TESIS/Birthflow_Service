using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Cambiando_propiedad_cervical_dilation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Value",
                schema: "Partograph",
                table: "CervicalDilations",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 22, 25, 39, 461, DateTimeKind.Local).AddTicks(2490), new Guid("110e6cf2-11c0-40ff-875c-163db0771537") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 22, 25, 39, 461, DateTimeKind.Local).AddTicks(2504), new Guid("7c4efa24-88db-4125-aaf0-5c0713aebd55") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 22, 25, 39, 461, DateTimeKind.Local).AddTicks(2506), new Guid("8fd5e6cd-bbb5-4ebe-b51b-ec3668f4cab6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Partograph",
                table: "CervicalDilations",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 48, 26, 846, DateTimeKind.Local).AddTicks(4286), new Guid("7f55c9bb-3a30-4338-a4e6-11003147fb9e") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 48, 26, 846, DateTimeKind.Local).AddTicks(4297), new Guid("cb0ab5e5-4ecb-4555-8bb5-ebf441944d4c") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 48, 26, 846, DateTimeKind.Local).AddTicks(4299), new Guid("aefaaf9e-f89e-41a1-9d8a-b53f1a197a34") });
        }
    }
}
