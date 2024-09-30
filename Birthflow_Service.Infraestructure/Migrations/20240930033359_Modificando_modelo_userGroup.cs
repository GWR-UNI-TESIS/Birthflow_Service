using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_modelo_userGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Group_GroupId1",
                schema: "Partograph",
                table: "UserGroup");

            migrationBuilder.DropPrimaryKey(
               name: "PK_UserGroup",
               schema: "Partograph",
               table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_GroupId1",
                schema: "Partograph",
                table: "UserGroup");

            migrationBuilder.DropColumn(
                name: "GroupId1",
                schema: "Partograph",
                table: "UserGroup");

            migrationBuilder.AlterColumn<long>(
                name: "GroupId",
                schema: "Partograph",
                table: "UserGroup",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId",
                schema: "Partograph",
                table: "UserGroup",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Group_GroupId",
                schema: "Partograph",
                table: "UserGroup",
                column: "GroupId",
                principalSchema: "Partograph",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroup",
                schema: "Partograph",
                table: "UserGroup",
                columns: new[] { "UserId", "GroupId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_Group_GroupId",
                schema: "Partograph",
                table: "UserGroup");

            migrationBuilder.DropIndex(
                name: "IX_UserGroup_GroupId",
                schema: "Partograph",
                table: "UserGroup");

            migrationBuilder.AlterColumn<int>(
                name: "GroupId",
                schema: "Partograph",
                table: "UserGroup",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "GroupId1",
                schema: "Partograph",
                table: "UserGroup",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 27, 8, 971, DateTimeKind.Local).AddTicks(4699), new Guid("fd0905dd-320b-4b35-8c12-29b1176803b2") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 27, 8, 971, DateTimeKind.Local).AddTicks(4714), new Guid("b82da4ec-4c89-4520-acc7-4fdd3469f143") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 29, 21, 27, 8, 971, DateTimeKind.Local).AddTicks(4715), new Guid("8848f375-21d0-4a9a-8f10-e8a5a2c1d13b") });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId1",
                schema: "Partograph",
                table: "UserGroup",
                column: "GroupId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_Group_GroupId1",
                schema: "Partograph",
                table: "UserGroup",
                column: "GroupId1",
                principalSchema: "Partograph",
                principalTable: "Group",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
