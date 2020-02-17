using System;
using System.Collections.Generic;
using System.Text;

namespace domain.EcommShipping.Itrellis.tests.Processors
{
	public class ShippingCalculatorFixture
	{
		public domain.EcommShipping.Itrellis.Processors.ShippingCalculator Sut { get; }

		public ShippingCalculatorFixture()
		{
			Sut = new Itrellis.Processors.ShippingCalculator();
		}
	}
}
