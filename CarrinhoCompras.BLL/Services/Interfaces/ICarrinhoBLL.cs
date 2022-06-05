using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.Services.Interfaces
{
	public interface ICarrinhoBLL
	{
		CarrinhoModel RetornarCarrinho();
		bool AdicionarProduto(int codigo);
		bool RemoverProduto(int codigo);
	}
}
