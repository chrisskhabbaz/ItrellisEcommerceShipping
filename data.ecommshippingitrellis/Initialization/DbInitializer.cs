using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using data.EcommShipping.Iitrellis.Context;
using data.EcommShipping.Iitrellis.Models;

namespace data.EcommShipping.Iitrellis.Initialization
{
	public static class DbInitializer
	{
		public static void Initialize(EcommerceContext context)
		{
			context.Database.EnsureCreated();
			// Look for any products.
			if (context.Products.Any())
			{
				return;   // DB has been seeded
			}

			var products = new Product[]
			{
				new Product{ProductName= "fugiat exercitation adipisicing", InventoryQuantity=43, MaxBusinessDaysToShip=13, DoesShipOnWeekends=true, InsertDateTime=DateTime.Now, IsEnabled= true},
				new Product { ProductName = "mollit cupidatat Lorem", InventoryQuantity = 70, MaxBusinessDaysToShip = 18, DoesShipOnWeekends = true, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "non quis sint", InventoryQuantity = 33, MaxBusinessDaysToShip = 15, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "voluptate cupidatat non", InventoryQuantity = 52, MaxBusinessDaysToShip = 18, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "anim amet occaecat", InventoryQuantity = 39, MaxBusinessDaysToShip = 19, DoesShipOnWeekends = true, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "cillum deserunt elit", InventoryQuantity = 47, MaxBusinessDaysToShip = 20, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "dipisicing reprehenderit et", InventoryQuantity = 71, MaxBusinessDaysToShip = 15, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
				new Product { ProductName = "ex mollit laboris", InventoryQuantity = 80, MaxBusinessDaysToShip = 15, DoesShipOnWeekends = false, InsertDateTime = DateTime.Now, IsEnabled = true },
			};
			foreach (Product p in products)
			{
				context.Products.Add(p);
			}
			context.SaveChanges();
		}
	}
}
