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
		///private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Pooling=False";
		private readonly string strconexao = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True";
        public ProdutoDao()
        {

            this.conexao = new SqlConnection(strconexao);
            this.conexao.Open();
        }

        //Adicionar
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

        //Atualizar
        internal void Atualizar(Produto p)
        {
            try
            {
                IDbCommand updateCommand = conexao.CreateCommand();
                updateCommand.CommandText = "UPDATE Produtos SET Nome = @nome, Categoria = @categoria, Preco = @preco WHERE Id = @Id";

                IDbDataParameter paramNome = new SqlParameter("nome", p.Nome);
                updateCommand.Parameters.Add(paramNome);

                IDbDataParameter paramCategoria = new SqlParameter("categoria", p.Categoria);
                updateCommand.Parameters.Add(paramCategoria);

                IDbDataParameter paramPreco = new SqlParameter("preco", p.Preco);
                updateCommand.Parameters.Add(paramPreco);

                IDbDataParameter paramId = new SqlParameter("Id", p.Id);
                updateCommand.Parameters.Add(paramId);

                updateCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        //Deletar
        internal void Deletar(Produto p)
        {
            try
            {
                IDbCommand deleteCommand = conexao.CreateCommand();
                deleteCommand.CommandText = "DELETE FROM Produto WHERE Id = @Id";

                IDbDataParameter paramId = new SqlParameter("Id", p.Id);
                deleteCommand.Parameters.Add(paramId);

                deleteCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        //Selecionar
        internal List<Produto> ListarProdutos()
        {
            var listaProdutos = new List<Produto>();
            try
            {
                IDbCommand selectCommand = conexao.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM Produtos";

                IDataReader resultado = selectCommand.ExecuteReader();

                while (resultado.Read())
                {
                    Produto p = new Produto();
                    p.Id = Convert.ToInt32(resultado["Id"]);
                    p.Nome = Convert.ToString(resultado["Nome"]);
                    p.Categoria = Convert.ToString(resultado["Categoria"]);
                    p.Preco = Convert.ToDouble(resultado["Preco"]);
                    listaProdutos.Add(p);
                }
                resultado.Close();
                return listaProdutos;

            }
            catch (Exception e)
            {
                throw new SystemException(e.Message, e);
            }

        }
    }
}
