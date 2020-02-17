using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data.EcommShipping.Iitrellis.Models;
using Microsoft.EntityFrameworkCore;

namespace data.EcommShipping.Iitrellis.Context
{
	public class Repository : IRepository
	{
		private readonly EcommerceContext _context;
		public Repository(EcommerceContext context)
		{
			_context = context;
		}
		public async Task<List<Product>> GetAllProducts()
		{
			var products = await _context.Products.ToListAsync();
			return products;
		}
	}
}
