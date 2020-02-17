using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain.EcommShipping.Itrellis
{
	public class ProductForUI
	{
		[Display(Name = "Product Name")]
		public string ProductName { get; set; }
		[Display(Name = "Available Quantity")]
		public int AvailableQuantity { get; set; }
		[Display(Name = "Shipping Date")]
		public string ShippingDate { get; set; }
	}
}
