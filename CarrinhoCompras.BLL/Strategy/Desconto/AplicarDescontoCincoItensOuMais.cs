using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.BLL.Strategy.Interfaces;

namespace CarrinhoCompras.BLL.Strategy.Desconto
{
	public class AplicarDescontoCincoItensOuMais : IDesconto
	{
		private readonly string _motivoDesconto;

		public AplicarDescontoCincoItensOuMais()
		{
			_motivoDesconto = "10% de desconto - 5 itens ou mais";
		}

		public CarrinhoModel AplicarDesconto(CarrinhoModel carrinho)
		{
			int qtdeMinimaItens = 5;

			if (carrinho.QtdeTotalItens >= qtdeMinimaItens)
			{
				carrinho.AplicarDesconto(car =>
				{
					decimal porcentagemDesconto = 10;
					carrinho.PrecoTotalComDesconto *= (1 - porcentagemDesconto / 100);
				}, _motivoDesconto);
			}

			return carrinho;
		}
	}
}
