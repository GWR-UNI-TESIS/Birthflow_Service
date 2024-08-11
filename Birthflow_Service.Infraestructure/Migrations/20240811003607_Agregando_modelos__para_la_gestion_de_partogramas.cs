using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_modelos__para_la_gestion_de_partogramas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Partograph");

            migrationBuilder.CreateTable(
                name: "Partographs",
                schema: "Partograph",
                columns: table => new
                {
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkTime = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partographs", x => x.PartographId);
                    table.ForeignKey(
                        name: "FK_Partographs_Usuario_CreatedBy",
                        column: x => x.CreatedBy,
                        principalSchema: "Auth",
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CervicalDilations",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(12,2)", nullable: false),
                    Hour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RemOrRam = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CervicalDilations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CervicalDilations_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChildbirthNote",
                schema: "Partograph",
                columns: table => new
                {
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apgar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temperature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caputto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Circular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lamniotico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Miccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Meconio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Expulsivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placenta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alumbramiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HuellaPlantar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildbirthNote", x => x.PartographId);
                    table.ForeignKey(
                        name: "FK_ChildbirthNote_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractionFrequency",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractionFrequency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractionFrequency_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FetalHeartRate",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeleteBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FetalHeartRate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FetalHeartRate_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalSurveillancesTable",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Letter = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    MaternalPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArterialPressure = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaternalPulse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FetalHeartRate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContractionsDuration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FrequencyContractions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalSurveillancesTable", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalSurveillancesTable_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PresentationPositionVariety",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HodgePlane = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresentationPositionVariety", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresentationPositionVariety_Partographs_PartographId",
                        column: x => x.PartographId,
                        principalSchema: "Partograph",
                        principalTable: "Partographs",
                        principalColumn: "PartographId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CervicalDilations_PartographId",
                schema: "Partograph",
                table: "CervicalDilations",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractionFrequency_PartographId",
                schema: "Partograph",
                table: "ContractionFrequency",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_FetalHeartRate_PartographId",
                schema: "Partograph",
                table: "FetalHeartRate",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSurveillancesTable_PartographId",
                schema: "Partograph",
                table: "MedicalSurveillancesTable",
                column: "PartographId");

            migrationBuilder.CreateIndex(
                name: "IX_Partographs_CreatedBy",
                schema: "Partograph",
                table: "Partographs",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_PresentationPositionVariety_PartographId",
                schema: "Partograph",
                table: "PresentationPositionVariety",
                column: "PartographId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CervicalDilations",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "ChildbirthNote",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "ContractionFrequency",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "FetalHeartRate",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "MedicalSurveillancesTable",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "PresentationPositionVariety",
                schema: "Partograph");

            migrationBuilder.DropTable(
                name: "Partographs",
                schema: "Partograph");
        }
    }
}
