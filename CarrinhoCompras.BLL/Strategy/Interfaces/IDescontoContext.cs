using CarrinhoCompras.BLL.Models;

namespace CarrinhoCompras.BLL.Strategy.Interfaces
{
	public interface IDescontoContext
	{
		IDesconto SetDesconto(IDesconto desconto);
		CarrinhoModel AplicarListaDescontos(CarrinhoModel carrinho);
	}
}
