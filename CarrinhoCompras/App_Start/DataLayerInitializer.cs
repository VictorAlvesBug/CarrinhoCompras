using CarrinhoCompras.DAL;
using CarrinhoCompras.DAL.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoCompras.App_Start
{
	public class DataLayerInitializer
	{
		public void Initialize(IServiceCollection services)
		{
			services.AddTransient<ICarrinhoDAL, CarrinhoDAL>();
		}
	}
}
