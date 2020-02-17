using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace domain.EcommShipping.Itrellis.Processors
{
	public class ShippingCalculator : IShippingCalculator
	{
		//METHOD TO CALCULATE SHIPPING DATE LOGIC
		//IT IS ASYNC AND SINCE THERE IS NO AWAITER, A Task.Run is used instead.
		public async Task<DateTime> GetShippingDate(int maxDaysToShip, bool doesShipOnWeekends)
		{
			DateTime shipDateToDisplay = DateTime.Now;
			//TO INCLUDE THE CURRENT DAY AS THE FIRST SHIPPING DAY WE HAVE TO DEDUCT A DAY FROM THE MAX DAYS TO SHIP.
			maxDaysToShip--;
			await Task.Run(() =>
			{
				if (doesShipOnWeekends)
				{
					DateTime startDate = DateTime.Now;
					DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
					shipDateToDisplay = expectedEndDate;
				}
				else
				{
					DateTime startDate = DateTime.Now;
					DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
					while (expectedEndDate.DayOfWeek == DayOfWeek.Saturday || expectedEndDate.DayOfWeek == DayOfWeek.Sunday)
					{
						expectedEndDate = expectedEndDate.AddDays(1);
					}
					shipDateToDisplay = expectedEndDate;
				}
			});
			return shipDateToDisplay;
		}
		//METHOD TO CALCULATE SHIPPING DATE LOGIC WITH A STARTING SHIP DATE
		//IT IS ASYNC AND SINCE THERE IS NO AWAITER, A Task.Run is used instead.
		public async Task<DateTime> GetShippingDateWithShipDate(int maxDaysToShip, bool doesShipOnWeekends, DateTime shipDate)
		{
			DateTime shipDateToDisplay = DateTime.Now;
			//TO INCLUDE THE CURRENT DAY AS THE FIRST SHIPPING DAY WE HAVE TO DEDUCT A DAY FROM THE MAX DAYS TO SHIP.
			maxDaysToShip--;
			await Task.Run(() =>
			{
				if (doesShipOnWeekends)

				{
					DateTime startDate = shipDate;
					DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
					shipDateToDisplay = expectedEndDate;
				}
				else
				{
					DateTime startDate = shipDate;
					DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
					while (expectedEndDate.DayOfWeek == DayOfWeek.Saturday || expectedEndDate.DayOfWeek == DayOfWeek.Sunday)
					{
						expectedEndDate = expectedEndDate.AddDays(1);
					}
					shipDateToDisplay = expectedEndDate;
				}
			});
			return shipDateToDisplay;
		}
	}
}
