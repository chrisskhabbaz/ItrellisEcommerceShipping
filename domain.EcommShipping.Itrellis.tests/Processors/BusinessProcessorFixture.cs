using System;
using System.Collections.Generic;
using System.Text;
using data.EcommShipping.Iitrellis.Context;
using data.EcommShipping.Iitrellis.Models;
using domain.EcommShipping.Itrellis.Processors;
using Moq;

namespace domain.EcommShipping.Itrellis.tests.Processors
{
	public class BusinessProcessorFixture
	{
		public Mock<IRepository> RepositoryMock { get; }
		public Mock<IShippingCalculator> ShippingCalculatorMock { get; }

		public domain.EcommShipping.Itrellis.Processors.BusinessProcessor Sut { get; }

		public BusinessProcessorFixture()
		{
			RepositoryMock = new Mock<IRepository>();
			ShippingCalculatorMock = new Mock<IShippingCalculator>();
			Sut = new BusinessProcessor(RepositoryMock.Object, ShippingCalculatorMock.Object);
		}

		public void ResetMocks()
		{
			ShippingCalculatorMock.Invocations.Clear();
			RepositoryMock.Invocations.Clear();
		}
		public List<Product> GetProductsFromDB()
		{
			List<Product> lProducts = new List<Product>();
			var products = new Product[]
		{
				new Product{ProductName= "fugiat exercitation adipisicing", InventoryQuantity=43, MaxBusinessDaysToShip=13, DoesShipOnWeekends=true, InsertDateTime=DateTime.Now, IsEnabled= true},
				new Product { ProductName = "mollit cupidatat Lorem", InventoryQuantity = 70, MaxBusinessDaysToShip = 18, DoesShipOnWeekends = true, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "non quis sint", InventoryQuantity = 33, MaxBusinessDaysToShip = 15, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "voluptate cupidatat non", InventoryQuantity = 52, MaxBusinessDaysToShip = 18, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },

		};
			foreach (Product p in products)
			{
				lProducts.Add(p);
			}
			return lProducts;
		}
	}
}
