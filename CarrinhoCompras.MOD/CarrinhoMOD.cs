using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.MOD
{
	public class CarrinhoMOD
	{
		public int Codigo { get; set; }
		public List<ProdutoMOD> ListaProdutos { get; set; }

		public CarrinhoMOD(List<ProdutoMOD> listaProdutos)
		{
			ListaProdutos = listaProdutos;
		}
	}
}
