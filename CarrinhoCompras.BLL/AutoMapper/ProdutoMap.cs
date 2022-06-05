using AutoMapper;
using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.MOD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrinhoCompras.BLL.AutoMapper
{
	public class ProdutoMap : Profile
	{
		public ProdutoMap()
		{
			CreateMap<ProdutoMOD, ProdutoModel>()
				.ForMember(
					destino => destino.PrecoUnitarioFormatado,
					origem => origem.MapFrom((mod, model) => model.PrecoUnitario.ToString("c2"))
				)
				.ForMember(
					destino => destino.PrecoSubTotalFormatado,
					origem => origem.MapFrom((mod, model) => model.PrecoSubTotal.ToString("c2"))
				);
		}
	}
}
