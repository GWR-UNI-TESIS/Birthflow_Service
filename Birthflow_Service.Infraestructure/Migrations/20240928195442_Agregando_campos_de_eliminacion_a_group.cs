using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_campos_de_eliminacion_a_group : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "Partograph",
                table: "Group",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Partograph",
                table: "Group",
                type: "bit",
                nullable: false,
                defaultValue: false);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "Partograph",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Partograph",
                table: "Group");

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
    }
}
