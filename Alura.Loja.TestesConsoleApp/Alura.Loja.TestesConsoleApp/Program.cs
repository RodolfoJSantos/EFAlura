using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.TestesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var repo = new LojaContext())
			{

				var produtos = repo.Produtos.ToList();
				foreach (var item in produtos)
				{
					Console.WriteLine(item);
				}

				Produto p = new Produto()
				{
					Nome = "stollen",
					Categoria = "Ação",
					Preco = 1.76
				};

				repo.Add(p);
				ExibirEntries(repo.ChangeTracker.Entries());

				//Console.WriteLine("====--====--====--====");
				//foreach (var item in repo.ChangeTracker.Entries())
				//{
				//	Console.WriteLine(item.State);
				//}
			}


            Console.WriteLine("\n\nComando executado");
            Console.ReadKey();
        }

		//Entity entry é a entidade de entrada capturada no caso produto
		private static void ExibirEntries(IEnumerable<EntityEntry> entry)
		{
			Console.WriteLine("=================================");
			foreach (var item in entry)
			{
				Console.WriteLine(item.Entity.ToString() +" - "+ item.State);
			}
		}

		private static void RecuperaProdutos()
		{
			using (var repo = new ProdutoDaoEntity())
			{
				var produtos = repo.Produtos();
				foreach (var item in produtos)
				{
					Console.WriteLine($"Nome do produto: {item.Nome}");
				}
			}
		}

		private static void GravarUsandoEntity()
		{
			Produto p = new Produto()
			{
				Nome = "Sabão em pó",
				Categoria = "Limpeza",
				Preco = 2.49
			};

			using (var repo = new ProdutoDaoEntity())
			{
				repo.Adicionar(p);
			}
		}

		private static void AtualizarProduto()
		{
			GravarUsandoEntity();
			RecuperaProdutos();

			using (var repo = new ProdutoDaoEntity())
			{
				var p = repo.Produtos().First();
				p.Nome = "Produto Editado";
				repo.Atualizar(p);
			}
			Console.WriteLine("---Nome foi editado----");
			RecuperaProdutos();

		}

		private static void ExcluirProdutos()
		{
			using (var repo = new ProdutoDaoEntity())
			{
				List<Produto> lista = repo.Produtos();
				foreach (var item in lista)
				{
					repo.Remover(item);
				}
			}
		}

		static void GravarAdo()
        {
            Produto p = new Produto()
            {
                Nome = "Herry Potter",
                Categoria = "Fixão",
                Preco = 19.59
            };
            using (var repo = new ProdutoDao())
            {
                repo.Adicionar(p);
            }
        }
    }
}
