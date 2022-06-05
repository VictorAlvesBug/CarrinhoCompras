using System;

namespace CarrinhoCompras.MOD
{
	public class ProdutoMOD
	{
		private static int CodigoMaximo { get; set; }
		public int Codigo { get; set; }
		public int QtdeEmEstoque { get; set; }
		public int QtdeSelecionada { get; set; }
		public decimal PrecoUnitario { get; set; }
		public decimal PrecoSubTotal
		{
			get
			{
				return QtdeSelecionada * PrecoUnitario;
			}
		}
		public string Nome { get; set; }

		public ProdutoMOD(string nome, decimal precoUnitario, int qtdeEmEstoque = 20)
		{
			CodigoMaximo++;

			Codigo = CodigoMaximo;
			Nome = nome;
			PrecoUnitario = precoUnitario;
			QtdeEmEstoque = qtdeEmEstoque;
			QtdeSelecionada = 0;
		}

		public bool Remover()
		{
			if (QtdeSelecionada > 0)
			{
				QtdeSelecionada--;
				return true;
			}

			return false;
		}

		public bool Adicionar()
		{
			if (QtdeSelecionada < QtdeEmEstoque)
			{
				QtdeSelecionada++;
				return true;
			}

			return false;
		}
	}
}
