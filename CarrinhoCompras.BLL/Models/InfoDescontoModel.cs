using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.Models
{
	public class InfoDescontoModel
	{
		public decimal PrecoAntes { get; set; }
		public string PrecoAntesFormatado
		{
			get
			{
				return PrecoAntes.ToString("c2");
			}
		}
		public decimal PrecoDepois { get; set; }
		public string PrecoDepoisFormatado
		{
			get
			{
				return PrecoDepois.ToString("c2");
			}
		}
		public decimal ValorDesconto
		{
			get
			{
				return PrecoAntes - PrecoDepois;
			}
		}
		public string ValorDescontoFormatado
		{
			get
			{
				return ValorDesconto.ToString("c2");
			}
		}

		public string MotivoDesconto { get; set; }
	}
}
