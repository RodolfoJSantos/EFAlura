using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.TestesConsoleApp
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set; }
		public IList<PromocaoProduto> Promocoes { get; set; }

		public override string ToString()
		{
			return $"Produto: {this.Id} - {this.Nome} - {this.Categoria} - {this.PrecoUnitario}";
		}
	}
}
