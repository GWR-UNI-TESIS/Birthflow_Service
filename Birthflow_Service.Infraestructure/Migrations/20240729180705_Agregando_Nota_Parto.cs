using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Birthflow_Service.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class Agregando_Nota_Parto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Partograph",
                table: "CervicalDilations",
                type: "decimal(12,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChildbirthNote",
                schema: "Partograph");

            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                schema: "Partograph",
                table: "CervicalDilations",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(12,2)");
        }
    }
}
