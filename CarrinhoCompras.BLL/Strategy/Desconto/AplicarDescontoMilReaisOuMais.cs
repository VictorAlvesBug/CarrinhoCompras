using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.BLL.Strategy.Interfaces;
using System.Linq;

namespace CarrinhoCompras.BLL.Strategy.Desconto
{
	public class AplicarDescontoMilReaisOuMais : IDesconto
	{
		private readonly string _motivoDesconto;

		public AplicarDescontoMilReaisOuMais()
		{
			_motivoDesconto = "R$ 150 de desconto - Compras a partir de R$ 1.000";
		}

		public CarrinhoModel AplicarDesconto(CarrinhoModel carrinho)
		{
			int precoMinimo = 1000;

			if (carrinho.PrecoTotalSemDesconto >= precoMinimo)
			{
				carrinho.AplicarDesconto(car =>
				{
					decimal valorDesconto = 150;
					car.PrecoTotalComDesconto -= valorDesconto;
				}, _motivoDesconto);
			}

			return carrinho;
		}
	}
}
