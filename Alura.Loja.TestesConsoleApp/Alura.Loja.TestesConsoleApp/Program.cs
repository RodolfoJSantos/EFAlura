using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alura.Loja.TestesConsoleApp
{
	class Program
    {
        static void Main(string[] args)
		{
			using (var contexto = new LojaContext())
			{
				var clientes = contexto.Clientes
					.Include(p => p.Endereco)
					.FirstOrDefault();
				Console.WriteLine($"Endereço de entrega: {0}", clientes.Endereco.Logradouro);
			}
			Console.ReadKey();
		}

		private static void EbibeProdutosDaPromocao()
		{
			using (var contexto2 = new LojaContext())
			{
				var promocao2 = contexto2
					.Promocoes
					.Include(p => p.Produtos) //inclui mais uma entidade para ser acompanhada
					.ThenInclude(pp => pp.Produto) //inclui outra entidade a partir da anterior
					.FirstOrDefault();

				Console.WriteLine("\nMostrando os produtos da promoção");
				foreach (var item in promocao2.Produtos)
				{
					Console.WriteLine(item.Produto + " - " + item.Promocao.Descricao);
				}
			}
		}

		private static void IncluirPromocao()
		{
			var promocao = new Promocao();
			promocao.Descricao = "Queima de estoque";
			promocao.DataInicio = new DateTime(2019, 9, 2);
			promocao.DataTermino = new DateTime(2019, 10, 20);

			using (var contexto = new LojaContext())
			{
				var produtos = contexto
					.Produtos
					.Where(p => p.Categoria == "Bebidas");

				foreach (var item in produtos)
				{
					promocao.IncluirProduto(item);
				}
				contexto.Promocoes.Add(promocao);

				ExibeEntries(contexto.ChangeTracker.Entries());
				//contexto.SaveChanges();
			}
		}

		private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() +" - "+ e.State);
            }
        }

		private static void MuitosParaMuitos()
		{
			var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
			var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
			var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

			var promocaoDePascoa = new Promocao();
			promocaoDePascoa.Descricao = "Páscoa Feliz";
			promocaoDePascoa.DataInicio = DateTime.Now;
			promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

			promocaoDePascoa.IncluirProduto(p1);
			promocaoDePascoa.IncluirProduto(p2);
			promocaoDePascoa.IncluirProduto(p3);


			using (var contexto = new LojaContext())
			{
				ExibeEntries(contexto.ChangeTracker.Entries());
				//contexto.Produtos.ToList();

				var promocao = contexto.Promocoes.Find(3);

				contexto.SaveChanges();
			}
		}
		private static void AdicionarCompra()
		{
			var paoFrances = new Produto();
			paoFrances.Nome = "Pão Francês";
			paoFrances.PrecoUnitario = 0.40;
			paoFrances.Unidade = "Unidade";
			paoFrances.Categoria = "Padaria";

			var compra = new Compra();
			compra.Quantidade = 6;
			compra.Produto = paoFrances;
			compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;
		}
       
    }
}
