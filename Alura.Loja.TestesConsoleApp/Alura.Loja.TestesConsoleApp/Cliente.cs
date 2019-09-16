namespace Alura.Loja.TestesConsoleApp
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Nome { get; internal set; }
		public Endereco Endereco { get;  set; }
	}
}