using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_seed_catalogo_de_tiempos_construccion_curva : Migration
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

            migrationBuilder.InsertData(
                schema: "Partograph",
                table: "WorkTimeItem",
                columns: new[] { "Id", "CervicalDilation", "Time", "WorkTimeId" },
                values: new object[,]
                {
                    { 1, 6.0, new TimeSpan(0, 2, 10, 0, 0), "VTI" },
                    { 2, 7.0, new TimeSpan(0, 1, 15, 0, 0), "VTI" },
                    { 3, 8.0, new TimeSpan(0, 1, 0, 0, 0), "VTI" },
                    { 4, 9.0, new TimeSpan(0, 0, 35, 0, 0), "VTI" },
                    { 5, 10.0, new TimeSpan(0, 0, 25, 0, 0), "VTI" },
                    { 6, 11.0, new TimeSpan(0, 0, 15, 0, 0), "VTI" },
                    { 7, 6.0, new TimeSpan(0, 2, 30, 0, 0), "HMI" },
                    { 8, 7.0, new TimeSpan(0, 1, 25, 0, 0), "HMI" },
                    { 9, 8.0, new TimeSpan(0, 0, 55, 0, 0), "HMI" },
                    { 10, 9.0, new TimeSpan(0, 0, 40, 0, 0), "HMI" },
                    { 11, 10.0, new TimeSpan(0, 0, 25, 0, 0), "HMI" },
                    { 12, 11.0, new TimeSpan(0, 0, 15, 0, 0), "HMI" },
                    { 13, 6.0, new TimeSpan(0, 2, 30, 0, 0), "HMR" },
                    { 14, 7.0, new TimeSpan(0, 1, 5, 0, 0), "HMR" },
                    { 15, 8.0, new TimeSpan(0, 0, 35, 0, 0), "HMR" },
                    { 16, 9.0, new TimeSpan(0, 0, 25, 0, 0), "HMR" },
                    { 17, 10.0, new TimeSpan(0, 0, 10, 0, 0), "HMR" },
                    { 18, 11.0, new TimeSpan(0, 0, 5, 0, 0), "HMR" },
                    { 19, 6.0, new TimeSpan(0, 3, 15, 0, 0), "HNI" },
                    { 20, 7.0, new TimeSpan(0, 1, 30, 0, 0), "HNI" },
                    { 21, 8.0, new TimeSpan(0, 1, 0, 0, 0), "HNI" },
                    { 22, 9.0, new TimeSpan(0, 0, 40, 0, 0), "HNI" },
                    { 23, 10.0, new TimeSpan(0, 0, 35, 0, 0), "HNI" },
                    { 24, 11.0, new TimeSpan(0, 0, 30, 0, 0), "HNI" },
                    { 25, 6.0, new TimeSpan(0, 2, 30, 0, 0), "HNR" },
                    { 26, 7.0, new TimeSpan(0, 1, 25, 0, 0), "HNR" },
                    { 27, 8.0, new TimeSpan(0, 1, 5, 0, 0), "HNR" },
                    { 28, 9.0, new TimeSpan(0, 0, 50, 0, 0), "HNR" },
                    { 29, 10.0, new TimeSpan(0, 0, 35, 0, 0), "HNR" },
                    { 30, 11.0, new TimeSpan(0, 0, 20, 0, 0), "HNR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Partograph",
                table: "WorkTimeItem",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 34, 56, 641, DateTimeKind.Local).AddTicks(7742), new Guid("13a5017e-2215-42c5-b07a-7bfaff9cb599") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 34, 56, 641, DateTimeKind.Local).AddTicks(7758), new Guid("80caf073-2ce7-4291-8699-4f6933ce378f") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 10, 5, 21, 34, 56, 641, DateTimeKind.Local).AddTicks(7760), new Guid("17402002-377e-468c-ba3c-51d223226499") });
        }
    }
}
