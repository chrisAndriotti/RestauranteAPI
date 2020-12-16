using RestauranteAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace RestauranteAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cargo> Cargos { get; set;}
        public DbSet<Venda> Vendas { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
           
        //}
    }
}
