using Microsoft.EntityFrameworkCore.Migrations;

namespace CursoEFCore.Aulas.Migrations
{
    public partial class PropagacaoDados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sequencias");

            migrationBuilder.CreateSequence<int>(
                name: "MinhaSequencia",
                schema: "sequencias",
                incrementBy: 2,
                minValue: 1L,
                maxValue: 10L,
                cyclic: true);

            migrationBuilder.CreateTable(
                name: "departamentos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR sequencias.MinhaSequencia"),
                    descricao = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    ativo = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    Excluido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departamentos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(80)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "VARCHAR(80)", nullable: false),
                    cpf = table.Column<string>(type: "CHAR(11)", nullable: false),
                    departamento_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_funcionarios_departamentos_departamento_id",
                        column: x => x.departamento_id,
                        principalTable: "departamentos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "id", "nome" },
                values: new object[] { 1, "Santa Catarina" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "id", "nome" },
                values: new object[] { 2, "Parana" });

            migrationBuilder.InsertData(
                table: "estados",
                columns: new[] { "id", "nome" },
                values: new object[] { 3, "Rio Grande do Sul" });

            migrationBuilder.CreateIndex(
                name: "ix_indice_composto",
                table: "departamentos",
                columns: new[] { "descricao", "ativo" },
                unique: true,
                filter: "descricao IS NOT NULL")
                .Annotation("SqlServer:FillFactor", 80);

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_departamento_id",
                table: "funcionarios",
                column: "departamento_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "funcionarios");

            migrationBuilder.DropTable(
                name: "departamentos");

            migrationBuilder.DropSequence(
                name: "MinhaSequencia",
                schema: "sequencias");
        }
    }
}
