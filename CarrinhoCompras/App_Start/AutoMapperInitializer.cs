using AutoMapper;
using CarrinhoCompras.BLL.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoCompras.App_Start
{
	public class AutoMapperInitializer
	{
		public void Initialize(IServiceCollection services)
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new ProdutoMap());
				mc.AddProfile(new CarrinhoMap());
			});

			IMapper mapper = mapperConfig.CreateMapper();

			services.AddSingleton(mapper);
		}
	}
}
