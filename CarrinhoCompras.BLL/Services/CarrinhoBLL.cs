using AutoMapper;
using CarrinhoCompras.BLL.Models;
using CarrinhoCompras.BLL.Services.Interfaces;
using CarrinhoCompras.BLL.Strategy.Interfaces;
using CarrinhoCompras.DAL.Interfaces;
using CarrinhoCompras.MOD;

namespace CarrinhoCompras.BLL.Services
{
	public class CarrinhoBLL : ICarrinhoBLL
	{
		private readonly ICarrinhoDAL _carrinhoDAL;
		private readonly IMapper _mapper;
		private readonly IDescontoContext _descontoContext;

		public CarrinhoBLL(ICarrinhoDAL produtoDAL, IMapper mapper, IDescontoContext descontoContext)
		{
			_carrinhoDAL = produtoDAL;
			_mapper = mapper;
			_descontoContext = descontoContext;
		}

		public CarrinhoModel RetornarCarrinho()
		{
			var mod = _carrinhoDAL.RetornarCarrinho();

			var model = _mapper.Map<CarrinhoMOD, CarrinhoModel>(mod);

			model = _descontoContext.AplicarListaDescontos(model);

			return model;
		}

		public bool RemoverProduto(int codigo)
		{
			return _carrinhoDAL.RemoverProduto(codigo);
		}

		public bool AdicionarProduto(int codigo)
		{
			return _carrinhoDAL.AdicionarProduto(codigo);
		}
	}
}
