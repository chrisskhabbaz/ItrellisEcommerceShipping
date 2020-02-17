using System;
using System.Collections.Generic;
using System.Text;
using domain.EcommShipping.Itrellis.Processors;
using Moq;

namespace api.EcommShipping.Itrellis.tests.Controllers
{
	public class ShippingControllerFixture
	{
		public Mock<IShippingCalculator> ShippingCalculatorMock { get; }
		public api.EcommShipping.Itrellis.Controllers.ShippingController Sut { get; }

		public ShippingControllerFixture()
		{
			ShippingCalculatorMock = new Mock<IShippingCalculator>();
			Sut = new api.EcommShipping.Itrellis.Controllers.ShippingController(ShippingCalculatorMock.Object);
		}

		public void ResetMocks()
		{
			ShippingCalculatorMock.Invocations.Clear();
		}
	}
}
