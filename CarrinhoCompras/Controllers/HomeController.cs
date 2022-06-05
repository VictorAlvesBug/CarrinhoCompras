using CarrinhoCompras.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CarrinhoCompras.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ICarrinhoBLL _carrinhoBLL;

		public HomeController(ILogger<HomeController> logger, ICarrinhoBLL carrinhoBLL)
		{
			_logger = logger;
			_carrinhoBLL = carrinhoBLL;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public JsonResult RetornarCarrinho()
		{
			var carrinho = _carrinhoBLL.RetornarCarrinho();

			return Json(carrinho);
		}

		[HttpPost]
		public JsonResult RemoverProduto(int codigo)
		{
			bool removeu = _carrinhoBLL.RemoverProduto(codigo);

			return Json(new { sucesso = removeu });
		}

		[HttpPost]
		public JsonResult AdicionarProduto(int codigo)
		{
			bool adicionou = _carrinhoBLL.AdicionarProduto(codigo);

			return Json(new { sucesso = adicionou });
		}

		[HttpPost]
		public JsonResult FinalizarCompra()
		{
			// MOCK FINALIZAÇÃO DE COMPRA
			return Json(new { sucesso = true });
		}
	}
}
