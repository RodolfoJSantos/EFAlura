using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.TestesConsoleApp
{
	public class LojaContext : DbContext
	{
		//private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Pooling=False";
		private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True";

		public DbSet<Produto> Produtos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(strconexao);
		}
	}
}