using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Modificando_userloginattempt_userId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginAttempt_User_UserId",
                schema: "Auth",
                table: "UserLoginAttempt");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Auth",
                table: "UserLoginAttempt",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginAttempt_User_UserId",
                schema: "Auth",
                table: "UserLoginAttempt",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLoginAttempt_User_UserId",
                schema: "Auth",
                table: "UserLoginAttempt");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Auth",
                table: "UserLoginAttempt",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserLoginAttempt_User_UserId",
                schema: "Auth",
                table: "UserLoginAttempt",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
