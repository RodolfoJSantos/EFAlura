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


            GravarAdo();

            Console.WriteLine("Comando executado");
            Console.ReadKey();
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
