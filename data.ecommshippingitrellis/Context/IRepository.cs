using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data.EcommShipping.Iitrellis.Models;

namespace data.EcommShipping.Iitrellis.Context
{
	public interface IRepository
	{
		Task<List<Product>> GetAllProducts();
	}
}
