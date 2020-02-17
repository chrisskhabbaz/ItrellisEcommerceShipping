using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommShippingItrellis.Models;

using domain.EcommShipping.Itrellis.Processors;
using System;

namespace EcommShippingItrellis.Controllers
{
	public class HomeController : Controller
	{
		private readonly IBusinessProcessor _businessProcessor;
		public HomeController(IBusinessProcessor businessProcessor)
		{
			_businessProcessor = businessProcessor;
		}
		public async Task<IActionResult> Index()
		{
			ViewData["shipDate"] = DateTime.Now.ToShortDateString();
			var products = await _businessProcessor.GetProductsForUI();
			return View(products);
		}
		public async Task<IActionResult> GetProductsWithDate(DateTime shipDate)
		{
			ViewData["shipDate"] = shipDate.ToShortDateString();
			var products = await _businessProcessor.GetProductsForUIWithShipDate(shipDate);
			return View("Index", products);
		}
		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
