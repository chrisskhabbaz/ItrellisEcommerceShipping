using data.EcommShipping.Iitrellis.Models;
using Microsoft.EntityFrameworkCore;

namespace data.EcommShipping.Iitrellis.Context
{
	public class EcommerceContext : DbContext
	{


		public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Product>().ToTable("Products");
		}
	}
}

