using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiConcessionaria.Migrations
{
    public partial class InserirFabricantes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('BMW')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Mercedes')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Porshe')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Fiat')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Ford')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Volkswagem')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Chevrolet')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Honda')");
            migrationBuilder.Sql("INSERT INTO Fabricantes(Nome) VALUES('Hiunday')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Fabricantes");
        }
    }
}
