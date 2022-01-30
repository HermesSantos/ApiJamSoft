using Microsoft.EntityFrameworkCore.Migrations;

namespace JamSoftApi.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Valor_Unitario = table.Column<int>(type: "INTEGER", nullable: false),
                    Qtd_Estoque = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
