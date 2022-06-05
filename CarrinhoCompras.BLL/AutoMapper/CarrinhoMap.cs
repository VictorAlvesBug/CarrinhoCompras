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
	public class CarrinhoMap : Profile
	{
		public CarrinhoMap()
		{
			CreateMap<CarrinhoMOD, CarrinhoModel>()
			.ForMember(
				destino => destino.PrecoTotalComDesconto,
				origem => origem.MapFrom((mod, model) => model.PrecoTotalSemDesconto)
			);
		}
	}
}
