using ApiConcessionaria.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiConcessionaria.Context
{
    public class ApiConcessionariaContext : DbContext
    {
        public ApiConcessionariaContext(DbContextOptions<ApiConcessionariaContext> options) : base(options) { }

        public DbSet<Veiculo>? Veiculos { get; set; }    
        public DbSet<Fabricante>? Fabricantes { get; set; }  

    }
}
