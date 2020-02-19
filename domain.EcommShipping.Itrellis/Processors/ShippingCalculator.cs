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
			await Task.Run(() =>
			{
				DateTime startDate = GetStartingShippingDate(DateTime.Now, doesShipOnWeekends);
				//TO INCLUDE THE CURRENT DAY AS THE FIRST SHIPPING DAY WE HAVE TO DEDUCT A DAY FROM THE MAX DAYS TO SHIP.
				maxDaysToShip--;
				DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
				shipDateToDisplay = GetWorkingDays(startDate, expectedEndDate, doesShipOnWeekends);
			});
			return shipDateToDisplay;
		}
		//METHOD TO CALCULATE SHIPPING DATE LOGIC WITH A STARTING SHIP DATE
		//IT IS ASYNC AND SINCE THERE IS NO AWAITER, A Task.Run is used instead.
		public async Task<DateTime> GetShippingDateWithShipDate(int maxDaysToShip, bool doesShipOnWeekends, DateTime shipDate)
		{
			DateTime shipDateToDisplay = DateTime.Now;
			await Task.Run(() =>
			{
				DateTime startDate = GetStartingShippingDate(shipDate, doesShipOnWeekends);
				//TO INCLUDE THE CURRENT DAY AS THE FIRST SHIPPING DAY WE HAVE TO DEDUCT A DAY FROM THE MAX DAYS TO SHIP.
				maxDaysToShip--;
				DateTime expectedEndDate = startDate.AddDays(maxDaysToShip);
				shipDateToDisplay = GetWorkingDays(startDate, expectedEndDate, doesShipOnWeekends);
			});
			return shipDateToDisplay;
		}
		private DateTime GetWorkingDays(DateTime from, DateTime to, bool doesShipOnWeekends)
		{
			if (doesShipOnWeekends)
				return to;
			else
			{
				for (var date = from; date <= to; date = date.AddDays(1))
				{
					if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
						to = to.AddDays(1);
				}
			}
			return to;
		}
		private DateTime GetStartingShippingDate(DateTime from, bool doesShipOnWeekends)
		{
			if (doesShipOnWeekends)
				return from;
			else
			{
				if (from.DayOfWeek == DayOfWeek.Saturday)
					from = from.AddDays(2);
				else if (from.DayOfWeek == DayOfWeek.Sunday)
					from = from.AddDays(1);
			}
			return from;
		}
	}
}
