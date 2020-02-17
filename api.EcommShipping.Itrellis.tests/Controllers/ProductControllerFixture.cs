using System;
using System.Collections.Generic;
using System.Text;
using domain.EcommShipping.Itrellis.Processors;
using Moq;

namespace api.EcommShipping.Itrellis.tests.Controllers
{
	public class ProductControllerFixture
	{
		public Mock<IBusinessProcessor> BusinessProcessorMock { get; }
		public api.EcommShipping.Itrellis.Controllers.ProductController Sut { get; }

		public ProductControllerFixture()
		{
			BusinessProcessorMock = new Mock<IBusinessProcessor>();
			Sut = new api.EcommShipping.Itrellis.Controllers.ProductController(BusinessProcessorMock.Object);
		}

		public void ResetMocks()
		{
			BusinessProcessorMock.Invocations.Clear();
		}
	}
}
