using CarrinhoCompras.BLL.Strategy.Desconto;
using CarrinhoCompras.BLL.Strategy.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CarrinhoCompras.App_Start
{
	public class StrategyInitializer
	{
		public void Initialize(IServiceCollection services)
		{
			services.AddScoped<IDesconto, AplicarDescontoCincoItensOuMais>();
			services.AddScoped<IDesconto, AplicarDescontoMilReaisOuMais>();
			services.AddScoped<IDesconto, AplicarDescontoMouseTecladoHeadset>();
			services.AddTransient<IDescontoContext, DescontoContext>();
		}
	}
}
