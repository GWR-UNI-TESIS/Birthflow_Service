using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_catalogo_de_tiempos_construccion_curva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTimeItem",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkTimeId = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    CervicalDilation = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTimeItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTimeItem_WorkTime_WorkTimeId",
                        column: x => x.WorkTimeId,
                        principalSchema: "Partograph",
                        principalTable: "WorkTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_WorkTimeItem_WorkTimeId",
                schema: "Partograph",
                table: "WorkTimeItem",
                column: "WorkTimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTimeItem",
                schema: "Partograph");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 33, 59, 256, DateTimeKind.Local).AddTicks(8441), new Guid("7d06d5a4-29ea-4461-8d28-791132ccf1e7") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 33, 59, 256, DateTimeKind.Local).AddTicks(8454), new Guid("c1de27d6-620e-4b00-a093-8275817e2e8e") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 33, 59, 256, DateTimeKind.Local).AddTicks(8455), new Guid("fbdfcc25-fa0e-4c2a-9c93-6b7533454efa") });
        }
    }
}
