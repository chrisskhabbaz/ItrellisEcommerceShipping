using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.EcommShipping.Iitrellis.Context;

namespace domain.EcommShipping.Itrellis.Processors
{
	public class BusinessProcessor : IBusinessProcessor
	{
		private readonly IRepository _repository;
		private readonly IShippingCalculator _shippingCalculator;
		public BusinessProcessor(IRepository repository, IShippingCalculator shippingCalculator)
		{
			_repository = repository;
			_shippingCalculator = shippingCalculator;
		}
		public async Task<List<ProductForUI>> GetProductsForUI()
		{
			var products = await _repository.GetAllProducts();
			var productsForUI = products.Select(p => new ProductForUI
			{
				ProductName = p.ProductName,
				AvailableQuantity = p.InventoryQuantity,
				ShippingDate = _shippingCalculator.GetShippingDate(p.MaxBusinessDaysToShip, p.DoesShipOnWeekends).Result.ToShortDateString()
			}).ToList();
			return productsForUI;
		}

		public async Task<List<ProductForUI>> GetProductsForUIWithShipDate(DateTime shipDate)
		{
			var products = await _repository.GetAllProducts();
			var productsForUI = products.Select(p => new ProductForUI
			{
				ProductName = p.ProductName,
				AvailableQuantity = p.InventoryQuantity,
				ShippingDate = _shippingCalculator.GetShippingDateWithShipDate(p.MaxBusinessDaysToShip, p.DoesShipOnWeekends, shipDate).Result.ToShortDateString()
			}).ToList();
			return productsForUI;
		}
	}
}
