using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace data.EcommShipping.Iitrellis.Models
{
	public class Product
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int InventoryQuantity { get; set; }
		public bool DoesShipOnWeekends { get; set; }
		public int MaxBusinessDaysToShip { get; set; }
		public bool IsEnabled { get; set; }
		public DateTime InsertDateTime { get; set; }
	}
}
