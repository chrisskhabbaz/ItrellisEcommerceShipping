using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.EcommShipping.Itrellis.tests.Controllers
{
	public class ShippingControllerFacts : IClassFixture<ShippingControllerFixture>
	{
		private readonly ShippingControllerFixture _testFixture;

		public ShippingControllerFacts(ShippingControllerFixture testFixture)
		{
			_testFixture = testFixture;
		}

		[Fact]
		public async Task ShippingController_GetShippingDate_ReturnsStatusOk()
		{
			//Arrange
			_testFixture.ResetMocks();
			_testFixture.ShippingCalculatorMock.Setup(x => x.GetShippingDate(It.IsAny<int>(), It.IsAny<bool>())).Returns(Task.FromResult(DateTime.Now));

			//Act
			var result = await _testFixture.Sut.GetShippingDate(10, true);
			var okResult = result as OkObjectResult;

			//Assert
			Assert.NotNull(result);
			Assert.Equal(200, okResult.StatusCode);
		}

		[Fact]
		public async Task ShippingController_GetShippingDateWithShipDate_ReturnsStatusOk()
		{
			//Arrange
			_testFixture.ResetMocks();
			_testFixture.ShippingCalculatorMock.Setup(x => x.GetShippingDateWithShipDate(It.IsAny<int>(), It.IsAny<bool>(), It.IsAny<DateTime>())).Returns(Task.FromResult(DateTime.Now));

			//Act
			var result = await _testFixture.Sut.GetShippingDateWithShipDate(10, true, DateTime.Now.AddDays(3));
			var okResult = result as OkObjectResult;

			//Assert
			Assert.NotNull(result);
			Assert.Equal(200, okResult.StatusCode);
		}

	
	}
}
