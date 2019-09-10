using Microsoft.EntityFrameworkCore.ChangeTracking;
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

            using (var contexto = new LojaContext())
            {

                //Select nos produtos
                var produtos = contexto.Produtos.ToList();

                //recupera ass entidades do contexto
                ExibeEntries(contexto.ChangeTracker.Entries());


                ////Adicionou um novo produto
                //var novoProduto = new Produto()
                //{
                //    Nome = "Desinfetante",
                //    Categoria = "Limpeza",
                //    Preco = 1.99
                //};

                //contexto.Produtos.Add(novoProduto);

                var p1 = produtos.First();
                contexto.Produtos.Remove(p1);

                ExibeEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges();
                ExibeEntries(contexto.ChangeTracker.Entries());

                var entry = contexto.Entry(p1);
                Console.WriteLine("\n\n"+ entry.Entity.ToString() +" - "+ entry.State);
            }
            Console.ReadKey();
        }

        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            Console.WriteLine("=====================");
            foreach (var item in entries)
            {
                Console.WriteLine(item.Entity.ToString() + " - " + item.State);
            }
        }
    }
}
