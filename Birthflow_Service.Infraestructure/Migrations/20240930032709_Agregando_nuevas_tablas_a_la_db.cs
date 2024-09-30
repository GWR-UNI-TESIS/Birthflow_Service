using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_nuevas_tablas_a_la_db : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassActual",
                schema: "Auth",
                table: "Password",
                newName: "IsCurrent");

            migrationBuilder.CreateTable(
                name: "PartographVersion",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartographDataJson = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographVersion_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PasswordHistory",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldPasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PasswordHistory_Password_PasswordEntityId",
                        column: x => x.PasswordEntityId,
                        principalSchema: "Auth",
                        principalTable: "Password",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PasswordHistory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginAttempt",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AttemptTimestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Success = table.Column<bool>(type: "bit", nullable: false),
                    FailureReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginAttempt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLoginAttempt_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserSessionHistory",
                schema: "Auth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionStartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SessionEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IPAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SessionToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessionHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessionHistory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartographAuditLog",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChangedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartographVersionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographAuditLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographAuditLog_PartographVersion_PartographVersionId",
                        column: x => x.PartographVersionId,
                        principalSchema: "Partograph",
                        principalTable: "PartographVersion",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PartographAuditLog_PartographVersionId",
                schema: "Partograph",
                table: "PartographAuditLog",
                column: "PartographVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographVersion_PartographId",
                schema: "Partograph",
                table: "PartographVersion",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistory_PasswordEntityId",
                schema: "Auth",
                table: "PasswordHistory",
                column: "PasswordEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PasswordHistory_UserId",
                schema: "Auth",
                table: "PasswordHistory",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLoginAttempt_UserId",
                schema: "Auth",
                table: "UserLoginAttempt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionHistory_UserId",
                schema: "Auth",
                table: "UserSessionHistory",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PartographAuditLog",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PasswordHistory",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserLoginAttempt",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "UserSessionHistory",
                schema: "Auth");

            migrationBuilder.DropTable(
                name: "PartographVersion",
                schema: "Partograph");

            migrationBuilder.RenameColumn(
                name: "IsCurrent",
                schema: "Auth",
                table: "Password",
                newName: "PassActual");

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
        }
    }
}
