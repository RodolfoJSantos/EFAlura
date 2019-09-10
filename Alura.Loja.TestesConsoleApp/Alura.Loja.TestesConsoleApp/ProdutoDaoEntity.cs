using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.TestesConsoleApp
{
	public class ProdutoDaoEntity : IProdutoDao, IDisposable
	{	
		private LojaContext _contexto;
		public ProdutoDaoEntity()
		{
			_contexto = new LojaContext();
		}

		public void Adicionar(Produto p)
		{
			_contexto.Add(p);
			_contexto.SaveChanges();
		}

		public void Atualizar(Produto p)
		{
			_contexto.Update(p);
			_contexto.SaveChanges();
		}

		public void Dispose()
		{
			_contexto.Dispose();
		}

		public List<Produto> Produtos()
		{
			return _contexto.Produtos.ToList();
		}

		public void Remover(Produto p)
		{
			_contexto.Remove(p);
			_contexto.SaveChanges();
		}
	}
}
