using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_nuevas_entidades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_User_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                schema: "Auth",
                table: "User");
            
            migrationBuilder.DropPrimaryKey(
                name: "PK_Password",
                schema: "Auth",
                table: "Password");

            migrationBuilder.EnsureSchema(
                name: "Notification");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                schema: "Auth",
                table: "Password",
                newName: "UserId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                schema: "Auth",
                table: "Password",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                schema: "Auth",
                table: "Password",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationType",
                schema: "Notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartographGroup",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PartographState",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAchived = table.Column<bool>(type: "bit", nullable: false),
                    Set = table.Column<bool>(type: "bit", nullable: false),
                    Silenced = table.Column<bool>(type: "bit", nullable: false),
                    Favorite = table.Column<bool>(type: "bit", nullable: false),
                    PartographStateEntityId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographState_PartographState_PartographStateEntityId",
                        column: x => x.PartographStateEntityId,
                        principalSchema: "Partograph",
                        principalTable: "PartographState",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographState_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartographState_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PermissionType",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroup",
                schema: "Partograph",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    GroupId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroup", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_UserGroup_Group_GroupId1",
                        column: x => x.GroupId1,
                        principalSchema: "Partograph",
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroup_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "Notification",
                columns: table => new
                {
                    NotificationId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identificator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ScheduledFor = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NotificationTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationType_NotificationTypeId",
                        column: x => x.NotificationTypeId,
                        principalSchema: "Notification",
                        principalTable: "NotificationType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartographGroupItem",
                schema: "Partograph",
                columns: table => new
                {
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PartographGroupId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographGroupItem", x => new { x.PartographId, x.PartographGroupId });
                    table.ForeignKey(
                        name: "FK_PartographGroupItem_PartographGroup_PartographGroupId",
                        column: x => x.PartographGroupId,
                        principalSchema: "Partograph",
                        principalTable: "PartographGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartographGroupItem_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PartographGroupShare",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    PermissionTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartographGroupEntityId = table.Column<long>(type: "bigint", nullable: true),
                    AccessPermissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographGroupShare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographGroupShare_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Partograph",
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographGroupShare_PartographGroup_PartographGroupEntityId",
                        column: x => x.PartographGroupEntityId,
                        principalSchema: "Partograph",
                        principalTable: "PartographGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographGroupShare_PermissionType_AccessPermissionId",
                        column: x => x.AccessPermissionId,
                        principalSchema: "Partograph",
                        principalTable: "PermissionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographGroupShare_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartographShare",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    PermissionTypeId = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartographEntityPartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AccessPermissionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographShare", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographShare_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Partograph",
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographShare_Partographs_PartographEntityPartographId",
                        column: x => x.PartographEntityPartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId");
                    table.ForeignKey(
                        name: "FK_PartographShare_PermissionType_AccessPermissionId",
                        column: x => x.AccessPermissionId,
                        principalSchema: "Partograph",
                        principalTable: "PermissionType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartographShare_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PartographNotification",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartographNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PartographNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "Notification",
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartographNotification_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                schema: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    GroupId = table.Column<long>(type: "bigint", nullable: true),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    Read = table.Column<bool>(type: "bit", nullable: false),
                    Delivered = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReadAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserNotification_Group_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "Partograph",
                        principalTable: "Group",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "Notification",
                        principalTable: "Notification",
                        principalColumn: "NotificationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotification_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Auth",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Partograph",
                table: "PermissionType",
                columns: new[] { "Id", "CreateAt", "Description", "Identificator", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7291), "Permisos de lectura", new Guid("6bd0f20d-a57d-455e-996f-18b0023de7c9"), "Lectura" },
                    { 2, new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7310), "Permisos de escritura", new Guid("798a7a44-2a16-463c-bd6d-30c321b3021e"), "Escritura" },
                    { 3, new DateTime(2024, 9, 11, 19, 28, 55, 306, DateTimeKind.Local).AddTicks(7312), "Permisos de lectura y escritura", new Guid("ba43f5bb-7e45-47a3-bea1-c22ded8519ba"), "Lectura y Escritura" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Password",
                schema: "Auth",
                table: "Password",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationTypeId",
                schema: "Notification",
                table: "Notification",
                column: "NotificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupItem_PartographGroupId",
                schema: "Partograph",
                table: "PartographGroupItem",
                column: "PartographGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "AccessPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_GroupId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_PartographGroupEntityId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "PartographGroupEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographGroupShare_UserId",
                schema: "Partograph",
                table: "PartographGroupShare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographNotification_NotificationId",
                schema: "Partograph",
                table: "PartographNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographNotification_PartographId",
                schema: "Partograph",
                table: "PartographNotification",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_AccessPermissionId",
                schema: "Partograph",
                table: "PartographShare",
                column: "AccessPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_GroupId",
                schema: "Partograph",
                table: "PartographShare",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_PartographEntityPartographId",
                schema: "Partograph",
                table: "PartographShare",
                column: "PartographEntityPartographId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographShare_UserId",
                schema: "Partograph",
                table: "PartographShare",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographState_PartographId",
                schema: "Partograph",
                table: "PartographState",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographState_PartographStateEntityId",
                schema: "Partograph",
                table: "PartographState",
                column: "PartographStateEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PartographState_UserId",
                schema: "Partograph",
                table: "PartographState",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGroup_GroupId1",
                schema: "Partograph",
                table: "UserGroup",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_GroupId",
                schema: "Notification",
                table: "UserNotification",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                schema: "Notification",
                table: "UserNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_UserId",
                schema: "Notification",
                table: "UserNotification",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_User_UsuarioId",
                schema: "Auth",
                table: "Password",
                column: "UserId",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Password_User_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.DropTable(
                name: "PartographGroupItem",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PartographGroupShare",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PartographNotification",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PartographShare",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PartographState",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "UserGroup",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "UserNotification",
                schema: "Notification");

            migrationBuilder.DropTable(
                name: "PartographGroup",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PermissionType",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "Notification");

            migrationBuilder.DropTable(
                name: "NotificationType",
                schema: "Notification");

            migrationBuilder.DropIndex(
                name: "IX_Password_UsuarioId",
                schema: "Auth",
                table: "Password");

            migrationBuilder.RenameColumn(
                name: "UserId",
                schema: "Auth",
                table: "Password",
                newName: "UsuarioId");

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                schema: "Auth",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                schema: "Auth",
                table: "Password",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "Auth",
                table: "Password",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Password_UsuarioId1",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Password_User_UsuarioId1",
                schema: "Auth",
                table: "Password",
                column: "UsuarioId1",
                principalSchema: "Auth",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
