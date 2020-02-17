using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace domain.EcommShipping.Itrellis.Processors
{
	public interface IShippingCalculator
	{
		Task<DateTime> GetShippingDate(int maxDaysToShip, bool doesShipOnWeekends);
		Task<DateTime> GetShippingDateWithShipDate(int maxDaysToShip, bool doesShipOnWeekends, DateTime shipDate);
	}
}
