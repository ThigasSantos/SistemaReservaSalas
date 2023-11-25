using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SistemaReservaSalas.Migrations
{
    /// <inheritdoc />
    public partial class migrationinicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Capacidade = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Sala",
                columns: new[] { "Id", "Ativo", "Capacidade", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, true, 10, "Sala de aula", "Sala 1" },
                    { 2, true, 20, "Sala de aula", "Sala 2" },
                    { 3, true, 20, "Laboratório de computação", "Lab Comp 1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sala");
        }
    }
}
