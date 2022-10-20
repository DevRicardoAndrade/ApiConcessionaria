using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Migrations
{
    public partial class InserirVeiculos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Veiculos (Nome, Ano_Fabricacao, Ano_Modelo, FabricanteId) VALUES('Celta', 2002, 2003, 7)");
            migrationBuilder.Sql("INSERT INTO Veiculos (Nome, Ano_Fabricacao, Ano_Modelo, FabricanteId) VALUES('Elantra', 2015, 2015, 9)");
            migrationBuilder.Sql("INSERT INTO Veiculos (Nome, Ano_Fabricacao, Ano_Modelo, FabricanteId) VALUES('City', 2016, 2016, 8)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Veiculos");
        }
    }
}
