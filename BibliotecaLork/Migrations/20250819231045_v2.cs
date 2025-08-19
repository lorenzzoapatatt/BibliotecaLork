using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BibliotecaLork.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LivroId1",
                table: "RelatorioLivroEmprestados",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "dataDevolucao",
                table: "RelatorioLivroEmprestados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "dataEmprestimo",
                table: "RelatorioLivroEmprestados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Preco",
                table: "Livros",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_RelatorioLivroEmprestados_LivroId1",
                table: "RelatorioLivroEmprestados",
                column: "LivroId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RelatorioLivroEmprestados_Livros_LivroId1",
                table: "RelatorioLivroEmprestados",
                column: "LivroId1",
                principalTable: "Livros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RelatorioLivroEmprestados_Livros_LivroId1",
                table: "RelatorioLivroEmprestados");

            migrationBuilder.DropIndex(
                name: "IX_RelatorioLivroEmprestados_LivroId1",
                table: "RelatorioLivroEmprestados");

            migrationBuilder.DropColumn(
                name: "LivroId1",
                table: "RelatorioLivroEmprestados");

            migrationBuilder.DropColumn(
                name: "dataDevolucao",
                table: "RelatorioLivroEmprestados");

            migrationBuilder.DropColumn(
                name: "dataEmprestimo",
                table: "RelatorioLivroEmprestados");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Livros");
        }
    }
}
