using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Eliminando_campo_innecesario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartographState_PartographState_PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState");

            migrationBuilder.DropIndex(
                name: "IX_PartographState_PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState");

            migrationBuilder.DropColumn(
                name: "PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState");

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 22, 11, 21, 59, 505, DateTimeKind.Local).AddTicks(2658), new Guid("1186bd9c-f93a-444a-926a-65dbfc0ddc0a") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 22, 11, 21, 59, 505, DateTimeKind.Local).AddTicks(2670), new Guid("8fd6322a-1923-4c83-97c2-814117047984") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 22, 11, 21, 59, 505, DateTimeKind.Local).AddTicks(2672), new Guid("013e6c5d-c420-4987-8534-dbfccf20c7ba") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState",
                type: "bigint",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 20, 4, 28, 335, DateTimeKind.Local).AddTicks(7355), new Guid("fa6c35ce-dffa-44dc-a6f7-d7b16a42e8da") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 20, 4, 28, 335, DateTimeKind.Local).AddTicks(7372), new Guid("002aae7b-8666-4058-aefa-5c86da1d9331") });

            migrationBuilder.UpdateData(
                schema: "Partograph",
                table: "PermissionType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreateAt", "Identificator" },
                values: new object[] { new DateTime(2024, 9, 16, 20, 4, 28, 335, DateTimeKind.Local).AddTicks(7374), new Guid("ab33145b-25e5-4635-a68c-bf513b242ea0") });

            migrationBuilder.CreateIndex(
                name: "IX_PartographState_PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState",
                column: "PartographStateEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PartographState_PartographState_PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState",
                column: "PartographStateEntityId",
                principalSchema: "Partograph",
                principalTable: "PartographState",
                principalColumn: "Id");
        }
    }
}
