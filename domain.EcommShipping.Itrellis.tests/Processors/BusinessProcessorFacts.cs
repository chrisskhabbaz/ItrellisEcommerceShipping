using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;

namespace domain.EcommShipping.Itrellis.tests.Processors
{
	public class BusinessProcessorFacts: IClassFixture<BusinessProcessorFixture>
	{
		private readonly BusinessProcessorFixture _testFixture;

		public BusinessProcessorFacts(BusinessProcessorFixture testFixture)
		{
			_testFixture = testFixture;
		}

		[Fact]
		public async Task BusinessProcessor_GetProductsForUI_VerifyResult()
		{
			//Arrange
			_testFixture.ResetMocks();
			var testResponse = _testFixture.GetProductsFromDB();
			var mockProductsForUI = new Mock<List<ProductForUI>>();
			_testFixture.RepositoryMock.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(testResponse));
			var expectedCount = testResponse.Count;

			//Act
			var result = await _testFixture.Sut.GetProductsForUI();

			//Assert
			Assert.NotNull(result);
			Assert.IsType<ProductForUI>(result.FirstOrDefault());
			Assert.Equal(result.Count, expectedCount);
		}

		[Fact]
		public async Task BusinessProcessor_GetProductsForUIWithShipDate_VerifyShippingDateInResult()
		{
			//Arrange
			_testFixture.ResetMocks();
			var testResponse = _testFixture.GetProductsFromDB();
			var mockProductsForUI = new Mock<List<ProductForUI>>();
			var shipDate = DateTime.Now.AddDays(3);
			var expectedShippingDate = DateTime.Now.AddDays(15);
			_testFixture.RepositoryMock.Setup(x => x.GetAllProducts()).Returns(Task.FromResult(testResponse));
			_testFixture.ShippingCalculatorMock.Setup(x => x.GetShippingDateWithShipDate(testResponse.FirstOrDefault().MaxBusinessDaysToShip, testResponse.FirstOrDefault().DoesShipOnWeekends, shipDate)).Returns(Task.FromResult(expectedShippingDate));
			var expectedCount = testResponse.Count;
		
	
			//Act
			var result = await _testFixture.Sut.GetProductsForUIWithShipDate(shipDate);
			var firstResult = result.FirstOrDefault();
			//Assert
			Assert.NotNull(result);
			Assert.IsType<ProductForUI>(result.FirstOrDefault());
			Assert.Equal(result.Count, expectedCount);
			Assert.Equal(expectedShippingDate.ToShortDateString(), firstResult.ShippingDate);

		}
	}
}
