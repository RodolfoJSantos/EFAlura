using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.TestesConsoleApp
{
    internal class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=Rodolfo;Initial Catalog=LojaDB;Integrated Security=True;Pooling=False");
        }
    }
}