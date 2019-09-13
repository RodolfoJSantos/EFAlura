using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;

namespace Alura.Loja.TestesConsoleApp
{
	class Program
    {
        static void Main(string[] args)
        {
			var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros"};
			var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas"};
			var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas"};

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
            Console.ReadKey();
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() +" - "+ e.State);
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
