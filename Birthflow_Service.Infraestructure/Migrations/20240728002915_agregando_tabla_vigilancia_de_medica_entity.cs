using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class agregando_tabla_vigilancia_de_medica_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicalSurveillancesTable",
                schema: "Partograph",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartographId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateIndex(
                name: "IX_MedicalSurveillancesTable_PartographId",
                schema: "Partograph",
                table: "MedicalSurveillancesTable",
                column: "PartographId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicalSurveillancesTable",
                schema: "Partograph");
        }
    }
}
