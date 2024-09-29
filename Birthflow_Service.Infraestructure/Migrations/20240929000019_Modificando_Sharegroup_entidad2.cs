using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_Sharegroup_entidad2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographGroupShare_PermissionType_AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographGroupShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropColumn(
                name: "AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 0, 19, 616, DateTimeKind.Local).AddTicks(7610), new Guid("f5623b42-ae50-4daf-ab25-98147d1fe6d0") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 0, 19, 616, DateTimeKind.Local).AddTicks(7622), new Guid("0d4957cb-04bb-4fd5-b4f2-0b62ca8a91ea") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 0, 19, 616, DateTimeKind.Local).AddTicks(7624), new Guid("628e0a13-33c7-440c-9450-8e4c3c4c3e37") });

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_PermissionTypeId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PermissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographGroupShare_PermissionType_PermissionTypeId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PermissionTypeId",
                principalSchema: "Partograph",
                principalTable: "PermissionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographGroupShare_PermissionType_PermissionTypeId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographGroupShare_PermissionTypeId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.AddColumn<int>(
                name: "AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 17, 50, 55, 61, DateTimeKind.Local).AddTicks(662), new Guid("cae70f95-9e0c-4416-8f18-b2b9fe86f35d") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 17, 50, 55, 61, DateTimeKind.Local).AddTicks(674), new Guid("a68d153d-d0e7-486b-86ba-14bcf44450e7") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 17, 50, 55, 61, DateTimeKind.Local).AddTicks(676), new Guid("6b153ea3-fdd0-46a7-9817-c2355d7f3994") });

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "AccessPermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographGroupShare_PermissionType_AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "AccessPermissionId",
                principalSchema: "Partograph",
                principalTable: "PermissionType",
                principalColumn: "Id");
        }
    }
}
