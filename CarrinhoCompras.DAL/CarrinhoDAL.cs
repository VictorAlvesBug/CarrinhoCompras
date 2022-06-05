using CarrinhoCompras.DAL.Interfaces;
using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarrinhoCompras.DAL
{
	public class CarrinhoDAL : ICarrinhoDAL
	{
		public CarrinhoMOD RetornarCarrinho()
		{
			return MockBancoDados.RetornarCarrinho();
		}
		public bool RemoverProduto(int codigo)
		{
			return MockBancoDados.RemoverProduto(codigo);
		}
		public bool AdicionarProduto(int codigo)
		{
			return MockBancoDados.AdicionarProduto(codigo);
		}
	}
}
