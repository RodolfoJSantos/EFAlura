﻿using Microsoft.EntityFrameworkCore;
using System;

namespace Alura.Loja.TestesConsoleApp
{
	public class LojaContext : DbContext
	{
        //private readonly string strconexao = @"Data Source=RODOLFO;Initial Catalog=LojaDB;Integrated Security=True";
		private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True";

		public DbSet<Produto> Produtos { get; set; }
        public DbSet<Compra> Compras { get; set; }
		public DbSet<Promocao> Promocoes { get; set; }
		public DbSet<Cliente> Clientes { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder
				.Entity<PromocaoProduto>()
				.HasKey(pp => new { pp.PromocaoId, pp.ProdutoId });

			modelBuilder
				.Entity<Endereco>()
				.ToTable("Enderecos");

			modelBuilder
				.Entity<Endereco>()
				.Property<int>("ClienteId");

			modelBuilder
				.Entity<Endereco>()
				.HasKey("ClienteId");
				
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(strconexao);
		}
	}
}