using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.Models
{
	public class ProdutoModel
	{
		public int Codigo { get; set; }
		public int QtdeEmEstoque { get; set; }
		public int QtdeSelecionada { get; set; }
		public decimal PrecoUnitario { get; set; }
		public string Nome { get; set; }
		public decimal PrecoSubTotal { get; set; }

		public string PrecoUnitarioFormatado { get; set; }
		public string PrecoSubTotalFormatado { get; set; }
	}
}
