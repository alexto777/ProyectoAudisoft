using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoAudisoft.Api.Migrations
{
    /// <inheritdoc />
    public partial class AjusteFinalModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Materia",
                table: "Notas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Materia",
                table: "Notas");
        }
    }
}
