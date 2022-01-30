using JamSoftApi.Models;
using Microsoft.EntityFrameworkCore;

namespace JamSoftApi.Data
{
    public class AppDbContext : DbContext
    {
        //Criaçao do banco de dados pelo EFCore
        public DbSet<ProdutoModel> Produtos { get; set; }
        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}