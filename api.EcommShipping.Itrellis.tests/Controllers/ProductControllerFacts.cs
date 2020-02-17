using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using domain.EcommShipping.Itrellis;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace api.EcommShipping.Itrellis.tests.Controllers
{
	public class ProductControllerFacts : IClassFixture<ProductControllerFixture>
	{
		private readonly ProductControllerFixture _testFixture;

		public ProductControllerFacts(ProductControllerFixture testFixture)
		{
			_testFixture = testFixture;
		}

		[Fact]
		public async Task ProductController_GetAllProducts_ReturnsStatusOk()
		{
			//Arrange
			_testFixture.ResetMocks();
			var products = new Mock<List<ProductForUI>>();
			_testFixture.BusinessProcessorMock.Setup(x => x.GetProductsForUI()).Returns(Task.FromResult(products.Object));

			//Act
			var result = await _testFixture.Sut.GetAllProducts();
			var okResult = result as OkObjectResult;

			//Assert
			Assert.NotNull(result);
			Assert.Equal(200, okResult.StatusCode);
		}

		[Fact]
		public async Task ProductController_GetAllProductsWithShipDate_ReturnsStatusOk()
		{
			//Arrange
			_testFixture.ResetMocks();
			var products = new Mock<List<ProductForUI>>();
			_testFixture.BusinessProcessorMock.Setup(x => x.GetProductsForUIWithShipDate(It.IsAny<DateTime>())).Returns(Task.FromResult(products.Object));

			//Act
			var result = await _testFixture.Sut.GetAllProductsWithShipDate(DateTime.Now.AddDays(2));
			var okResult = result as OkObjectResult;

			//Assert
			Assert.NotNull(result);
			Assert.Equal(200, okResult.StatusCode);
		}

	}
}
