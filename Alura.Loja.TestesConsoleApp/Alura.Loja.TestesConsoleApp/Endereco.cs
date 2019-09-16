namespace Alura.Loja.TestesConsoleApp
{
	public class Endereco
	{
		public int Numero { get; set; }
		public string Logradouro { get; set; }
		public string Complemento { get; set; }
		public string Bairro { get; internal set; }
		public string Cidade { get; internal set; }
		public Cliente Cliente { get; set; }
	}
}