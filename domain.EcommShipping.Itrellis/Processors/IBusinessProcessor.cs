using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace domain.EcommShipping.Itrellis.Processors
{
	public interface IBusinessProcessor
	{
		Task<List<ProductForUI>> GetProductsForUI();
		Task<List<ProductForUI>> GetProductsForUIWithShipDate(DateTime shipDate);
	}
}
