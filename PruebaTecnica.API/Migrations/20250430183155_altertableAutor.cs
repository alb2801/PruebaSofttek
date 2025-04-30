using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaTecnica.API.Migrations
{
    /// <inheritdoc />
    public partial class altertableAutor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrimerApellido",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "PrimerNombre",
                table: "Autores");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                table: "Autores");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Libros",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CorreoElectronico",
                table: "Autores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CiudadProcedencia",
                table: "Autores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NombreCompleto",
                table: "Autores",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreCompleto",
                table: "Autores");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Libros",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "CorreoElectronico",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "CiudadProcedencia",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PrimerApellido",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrimerNombre",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SegundoNombre",
                table: "Autores",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
