using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using domain.EcommShipping.Itrellis;
using domain.EcommShipping.Itrellis.Processors;
using Microsoft.AspNetCore.Mvc;

namespace api.EcommShipping.Itrellis.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class ProductController : Controller
    {
		private readonly IBusinessProcessor _businessProcessor;

		public ProductController(IBusinessProcessor businessProcessor)
		{
			_businessProcessor = businessProcessor;
		}
		/// <summary>
		/// Get All Products - Retrieves all products from Database and formats it for UI.
		/// </summary>
		/// <returns>Returns a list representation of the products To Display on the UI</returns>
		/// <response code="200">A List of ProductForUI is returned</response>
		[HttpGet("GetAllProducts")]
		[ProducesResponseType(typeof(List<ProductForUI>), 200)]
		public async Task<IActionResult> GetAllProducts()
		{
			var response = await _businessProcessor.GetProductsForUI();
			return Ok(response);
		}
		/// <summary>
		/// Get All Products - Retrieves all products from Database and formats it for UI based on a shipDate
		/// </summary>
		/// <returns>Returns a list representation of the products To Display on the UI</returns>
		/// <remarks>Must provide a shipDate.</remarks>
		/// <param name="shipDate">Required: shipDate</param>
		/// <response code="200">A List of ProductForUI is returned</response>
		[HttpGet("GetAllProductsWithShipDate")]
		[ProducesResponseType(typeof(List<ProductForUI>), 200)]
		public async Task<IActionResult> GetAllProductsWithShipDate(DateTime shipDate)
		{
			var response = await _businessProcessor.GetProductsForUIWithShipDate(shipDate);
			return Ok(response);
		}
	}
}