using CarrinhoCompras.BLL.Services;
using CarrinhoCompras.BLL.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoCompras.App_Start
{
	public class BusinessInitializer
	{
		public void Initialize(IServiceCollection services)
		{
			services.AddTransient<ICarrinhoBLL, CarrinhoBLL>();
		}
	}
}
