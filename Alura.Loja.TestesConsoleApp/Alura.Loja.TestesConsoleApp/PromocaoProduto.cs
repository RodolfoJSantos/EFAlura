﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.TestesConsoleApp
{
	public class PromocaoProduto
	{
		public int ProdutoId { get; set; }
		public Produto Produto { get; set; }
		public int PromocaoId { get; set; }
		public Promocao Promocao { get; set; }
	}
}
