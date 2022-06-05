using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.Models
{
	public class CarrinhoModel
	{
		public int Codigo { get; set; }
		public List<ProdutoModel> ListaProdutos { get; set; }

		public int QtdeTotalItens
		{
			get
			{
				if (ListaProdutos == null || !ListaProdutos.Any())
				{
					return 0;
				}

				return ListaProdutos.Sum(produto => produto.QtdeSelecionada);
			}
		}

		public decimal PrecoTotalSemDesconto
		{
			get
			{
				if (ListaProdutos == null || !ListaProdutos.Any())
				{
					return 0;
				}

				return ListaProdutos.Sum(produto => produto.PrecoSubTotal);
			}
		}

		public string PrecoTotalSemDescontoFormatado
		{
			get
			{
				return PrecoTotalSemDesconto.ToString("c2");
			}
		}

		public decimal PrecoTotalComDesconto { get; set; }

		public string PrecoTotalComDescontoFormatado
		{
			get
			{
				return PrecoTotalComDesconto.ToString("c2");
			}
		}

		public List<InfoDescontoModel> ListaInfoDescontosAplicados { get; set; }

		public CarrinhoModel()
		{
			ListaInfoDescontosAplicados = new List<InfoDescontoModel>();
		}

		public void AplicarDesconto(Action<CarrinhoModel> funcAplicarDesconto, string motivoDesconto)
		{
			InfoDescontoModel infoDesconto = new InfoDescontoModel();

			infoDesconto.PrecoAntes = PrecoTotalComDesconto;
			funcAplicarDesconto(this);
			infoDesconto.PrecoDepois = PrecoTotalComDesconto;
			infoDesconto.MotivoDesconto = motivoDesconto;

			ListaInfoDescontosAplicados.Add(infoDesconto);
		}
	}
}
