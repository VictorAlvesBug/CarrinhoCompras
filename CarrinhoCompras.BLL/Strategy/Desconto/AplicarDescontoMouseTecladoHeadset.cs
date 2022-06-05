using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.BLL.Strategy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.Strategy.Desconto
{
	public class AplicarDescontoMouseTecladoHeadset
		: IDesconto
	{
		private readonly string _motivoDesconto;
		public AplicarDescontoMouseTecladoHeadset()
		{
			_motivoDesconto = "15% de desconto - Combo Mouse + Teclado + Headset";
		}
		public CarrinhoModel AplicarDesconto(CarrinhoModel carrinho)
		{
			List<string> listaProdutosNecessarios = new List<string> { "Mouse", "Teclado", "Headset" };
			string strNomesProdutosNecessarios = string.Join(",", listaProdutosNecessarios.OrderBy(nomeProduto => nomeProduto));

			var listaProdutos = carrinho.ListaProdutos.Where(produto => produto.QtdeSelecionada > 0).ToList();
			var listaNomeProdutos = listaProdutos.Select(produto => produto.Nome).ToList();
			string strNomesProdutos = string.Join(",", listaNomeProdutos.OrderBy(nomeProduto => nomeProduto));

			if (strNomesProdutosNecessarios == strNomesProdutos)
			{
				int limiteDescontoAcumulativo = 3;

				int qtdeVezesAplicarDesconto = Math.Min(listaProdutos.Min(produto => produto.QtdeSelecionada), limiteDescontoAcumulativo);

				carrinho.AplicarDesconto(car =>
				{
					decimal porcentagemDesconto = 15 * qtdeVezesAplicarDesconto;
					car.PrecoTotalComDesconto *= (1 - porcentagemDesconto / 100);
				}, $"({qtdeVezesAplicarDesconto}x) {_motivoDesconto}");
			}

			return carrinho;
		}
	}
}
