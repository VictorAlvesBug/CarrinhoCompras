using CarrinhoCompras.BLL.Models;

namespace CarrinhoCompras.BLL.Strategy.Interfaces
{
	public interface IDesconto
	{
		CarrinhoModel AplicarDesconto(CarrinhoModel carrinho);
	}
}
