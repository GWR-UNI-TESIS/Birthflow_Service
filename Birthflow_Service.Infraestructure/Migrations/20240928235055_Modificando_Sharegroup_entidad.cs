using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_Sharegroup_entidad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographGroupShare_PartographGroup_PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographGroupShare_PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropColumn(
                name: "PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropColumn(
                name: "PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.AddColumn<long>(
                name: "PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare",
                type: "bigint",
                nullable:true);

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PartographGroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographGroupShare_PartographGroup_PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PartographGroupId",
                principalSchema: "Partograph",
                principalTable: "PartographGroup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographGroupShare_PartographGroup_PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.DropIndex(
                name: "IX_PartographGroupShare_PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare");

            migrationBuilder.AlterColumn<Guid>(
                name: "PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupShare",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 13, 54, 42, 741, DateTimeKind.Local).AddTicks(4968), new Guid("f0e6b1e3-fcf9-47ef-a5bd-6d216e75a34c") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 13, 54, 42, 741, DateTimeKind.Local).AddTicks(4982), new Guid("1f17af46-1f74-4859-b29c-6875899b478a") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 28, 13, 54, 42, 741, DateTimeKind.Local).AddTicks(4984), new Guid("96c1c81b-662e-41f9-9007-49d5358f9dc6") });

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PartographGroupEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographGroupShare_PartographGroup_PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PartographGroupEntityId",
                principalSchema: "Partograph",
                principalTable: "PartographGroup",
                principalColumn: "Id");
        }
    }
}
