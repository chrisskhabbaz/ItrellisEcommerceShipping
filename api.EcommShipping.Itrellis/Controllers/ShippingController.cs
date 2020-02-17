using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using domain.EcommShipping.Itrellis.Processors;
using Microsoft.AspNetCore.Mvc;

namespace api.EcommShipping.Itrellis.Controllers
{
	[Route("api/[controller]")]
	[Produces("application/json")]
	public class ShippingController : Controller
    {
		private readonly IShippingCalculator _shippingCalculator;

		public ShippingController(IShippingCalculator shippingCalculator)
		{
			_shippingCalculator = shippingCalculator;
		}

		/// <summary>
		/// GetShippingDate - Retrieves calculated shipping date for a product.
		/// </summary>
		/// <returns>Returns a string representation of the shipping date</returns>
		/// <remarks>Must provide a max days to ship</remarks>
		/// <remarks>Must provide if product ships on weekends.</remarks>
		/// <param name="maxDaysToShip">Required: maxDaysToShip</param>
		/// <param name="doesShipOnWeekends">Required: doesShipOnWeekends</param>
		/// <response code="200">A Calculated Shipping Date is returned</response>
		[HttpGet("GetShippingDate")]
		[ProducesResponseType(typeof(string), 200)]
		public async Task<IActionResult> GetShippingDate([Required]int maxDaysToShip, [Required]bool doesShipOnWeekends)
		{
			var response = await _shippingCalculator.GetShippingDate(maxDaysToShip, doesShipOnWeekends);
			return Ok(response);
		}

		/// <summary>
		/// GetShippingDateWithShipDate - Retrieves calculated shipping date for a product given a starting ship date.
		/// </summary>
		/// <returns>Returns a string representation of the shipping date</returns>
		/// <remarks>Must provide a max days to ship</remarks>
		/// <remarks>Must provide if product ships on weekends.</remarks>
		/// <remarks>Must provide a starting ship date.</remarks>
		/// <param name="maxDaysToShip">Required: maxDaysToShip</param>
		/// <param name="doesShipOnWeekends">Required: doesShipOnWeekends</param>
		/// <param name="shipDate">Required: shipDate</param>
		/// <response code="200">A Calculated Shipping Date is returned</response>
		[HttpGet("GetShippingDateWithShipDate")]
		[ProducesResponseType(typeof(string), 200)]
		public async Task<IActionResult> GetShippingDateWithShipDate([Required]int maxDaysToShip, [Required]bool doesShipOnWeekends, [Required]DateTime shipDate)
		{
			var response = await _shippingCalculator.GetShippingDateWithShipDate(maxDaysToShip, doesShipOnWeekends, shipDate);
			return Ok(response);
		}
	}
}
