using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace domain.EcommShipping.Itrellis.tests.Processors
{
	public class ShippingCalculatorFacts : IClassFixture<ShippingCalculatorFixture>
	{
		private readonly ShippingCalculatorFixture _testFixture;

		public ShippingCalculatorFacts(ShippingCalculatorFixture testFixture)
		{
			_testFixture = testFixture;
		}

		[Fact]
		public void ShippingCalculatorFacts_GetShippingDate_ShippingDateReturnedVerified()
		{
			//Arrange
			var maxDaysToShip = 3;
			var doesShipOnWeekEnds = true;
			var expectedResult = DateTime.Now.AddDays(2);

			//Act
			var result = _testFixture.Sut.GetShippingDate(maxDaysToShip, doesShipOnWeekEnds).Result;

			//Assert
			Assert.IsType<DateTime>(result);
			Assert.Equal(expectedResult.ToShortDateString(), result.ToShortDateString());
			
		}
		[Fact]
		public void ShippingCalculatorFacts_GetShippingDateWithShipDate_ShippingDateReturnedVerified()
		{
			//Arrange
			var maxDaysToShip = 3;
			var doesShipOnWeekEnds = true;
			var startingShipDate = DateTime.Now.AddDays(5);
			var expectedResult = DateTime.Now.AddDays(7);

			//Act
			var result = _testFixture.Sut.GetShippingDateWithShipDate(maxDaysToShip, doesShipOnWeekEnds, startingShipDate).Result;

			//Assert
			Assert.IsType<DateTime>(result);
			Assert.Equal(expectedResult.ToShortDateString(), result.ToShortDateString());

		}
	}
}

