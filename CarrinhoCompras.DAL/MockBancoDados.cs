using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.DAL
{
	public class MockBancoDados
	{
		private static CarrinhoMOD Carrinho;

		public static CarrinhoMOD RetornarCarrinho()
		{
			if (Carrinho != null)
			{
				return Carrinho;
			}

			var listaProdutos = new List<ProdutoMOD>
			{
				new ProdutoMOD("Teclado", 300),
				new ProdutoMOD("Headset", 550),
				new ProdutoMOD("Airdots", 120),
				new ProdutoMOD("Mouse", 75),
				new ProdutoMOD("Cadeira", 1800),
				new ProdutoMOD("Carregador Samsung", 120),
				new ProdutoMOD("Carregador iPhone", 200),
				new ProdutoMOD("Celular Samsung", 1900),
				new ProdutoMOD("Celular iPhone", 4900)
			};

			Carrinho = new CarrinhoMOD(listaProdutos);

			return Carrinho;
		}

		public static bool RemoverProduto(int codigo)
		{
			if (Carrinho == null || Carrinho.ListaProdutos == null)
			{
				return false;
			}

			for (int indice = 0; indice < Carrinho.ListaProdutos.Count; indice++)
			{
				if (Carrinho.ListaProdutos[indice].Codigo == codigo)
				{
					return Carrinho.ListaProdutos[indice].Remover();
				}
			}

			return false;
		}

		public static bool AdicionarProduto(int codigo)
		{
			if (Carrinho == null || Carrinho.ListaProdutos == null)
			{
				return false;
			}

			for (int indice = 0; indice < Carrinho.ListaProdutos.Count; indice++)
			{
				if (Carrinho.ListaProdutos[indice].Codigo == codigo)
				{
					return Carrinho.ListaProdutos[indice].Adicionar();
				}
			}

			return false;
		}
	}
}
