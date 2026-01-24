using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAudisoft.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixCiclosYDto3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Materia",
                table: "Profesores",
                newName: "Especialidad");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Notas",
                type: "decimal(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(3,2)",
                oldPrecision: 3,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Especialidad",
                table: "Profesores",
                newName: "Materia");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Notas",
                type: "decimal(3,2)",
                precision: 3,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5,
                oldScale: 2);
        }
    }
}
