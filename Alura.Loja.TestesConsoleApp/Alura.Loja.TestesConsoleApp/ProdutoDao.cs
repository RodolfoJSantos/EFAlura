using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.TestesConsoleApp
{
    public class ProdutoDao : IDisposable
    {
        public void Dispose()
        {
            this.conexao.Close();
        }

        private IDbConnection conexao;

        public ProdutoDao()
        {
            this.conexao = new SqlConnection("");
            this.conexao.Open();
        }

        internal void Adicionar(Produto p)
        {
            try
            {
                IDbCommand insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Produtos (Nome, Categoria, Preco) VALUES (@nome, @categoria, @preco)";

                IDbDataParameter paramNome = new SqlParameter("nome", p.Nome);
                insertCmd.Parameters.Add(paramNome);

                IDbDataParameter paramCategoria = new SqlParameter("categoria", p.Categoria);
                insertCmd.Parameters.Add(paramCategoria);

                IDataParameter paramPreco = new SqlParameter("preco", p.Preco);
                insertCmd.Parameters.Add(paramPreco);

                insertCmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message, e);
            }
        }
    }
}
