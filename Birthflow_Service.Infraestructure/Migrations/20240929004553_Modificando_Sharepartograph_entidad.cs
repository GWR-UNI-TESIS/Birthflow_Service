using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_Sharepartograph_entidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographShare_Partographs_PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropForeignKey(
                name: "FK_PartographShare_PermissionType_AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographShare_PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropColumn(
                name: "AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropColumn(
                name: "PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.RenameColumn(
                name: "PartographGroupId",
                schema: "Partograph",
                table: "PartographShare",
                newName: "PartographId");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 45, 53, 479, DateTimeKind.Local).AddTicks(3322), new Guid("9fd1cdec-d951-4255-b4a6-0037a5543549") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 45, 53, 479, DateTimeKind.Local).AddTicks(3334), new Guid("40f9feb0-b509-4534-b531-395224d27e7c") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 18, 45, 53, 479, DateTimeKind.Local).AddTicks(3336), new Guid("0908ebfe-ed00-42da-8986-16289fbde81d") });

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_PartographId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_PermissionTypeId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PermissionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographShare_Partographs_PartographId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PartographId",
                principalSchema: "Partograph",
                principalTable: "Partographs",
                principalColumn: "PartographId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartographShare_PermissionType_PermissionTypeId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PermissionTypeId",
                principalSchema: "Partograph",
                principalTable: "PermissionType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographShare_Partographs_PartographId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropForeignKey(
                name: "FK_PartographShare_PermissionType_PermissionTypeId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographShare_PartographId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographShare_PermissionTypeId",
                schema: "Partograph",
                table: "PartographShare");

            migrationBuilder.RenameColumn(
                name: "PartographId",
                schema: "Partograph",
                table: "PartographShare",
                newName: "PartographGroupId");

            migrationBuilder.AddColumn<int>(
                name: "AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare",
                type: "uniqueidentifier",
                nullable: true);

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
                name: "IX_PartographShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare",
                column: "AccessPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PartographEntityPartographId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographShare_Partographs_PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PartographEntityPartographId",
                principalSchema: "Partograph",
                principalTable: "Partographs",
                principalColumn: "PartographId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographShare_PermissionType_AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare",
                column: "AccessPermissionId",
                principalSchema: "Partograph",
                principalTable: "PermissionType",
                principalColumn: "Id");
        }
    }
}
