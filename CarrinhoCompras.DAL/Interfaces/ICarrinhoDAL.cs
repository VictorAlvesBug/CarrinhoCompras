using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.DAL.Interfaces
{
	public interface ICarrinhoDAL
	{
		CarrinhoMOD RetornarCarrinho();
		bool RemoverProduto(int codigo);
		bool AdicionarProduto(int codigo);
	}
}
