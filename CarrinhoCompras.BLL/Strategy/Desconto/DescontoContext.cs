using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.BLL.Strategy.Interfaces;
using System.Collections.Generic;

namespace CarrinhoCompras.BLL.Strategy.Desconto
{
	public class DescontoContext : IDescontoContext
	{
		private readonly IEnumerable<IDesconto> _listaDesconto;

		public DescontoContext(IEnumerable<IDesconto> listaDesconto)
		{
			_listaDesconto = listaDesconto;
		}

		public IDesconto SetDesconto(IDesconto desconto)
		{
			return desconto;
		}

		public CarrinhoModel AplicarListaDescontos(CarrinhoModel carrinho)
		{
			foreach (var desconto in _listaDesconto)
			{
				carrinho = SetDesconto(desconto).AplicarDesconto(carrinho);
			}

			return carrinho;
		}
	}
}
