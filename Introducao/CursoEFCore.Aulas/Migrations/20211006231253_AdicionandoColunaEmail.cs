using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore.Aulas.Migrations
{
    public partial class AdicionandoColunaEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "clientes",
                type: "VARCHAR(80)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "clientes");
        }
    }
}
