using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.TestesConsoleApp
{
	public class LojaContext : DbContext
	{
        private readonly string strconexao = @"Data Source=RODOLFO;Initial Catalog=LojaDB;Integrated Security=True";
        //private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True";

		public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(strconexao);
		}
	}
}