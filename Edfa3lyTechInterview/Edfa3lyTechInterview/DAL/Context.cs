using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Edfa3lyTechInterview.DAL
{
	public class Context : DbContext
	{
		public Context()
					: base("name=Context")
		{
		}

		public DbSet<Cart> Carts { get; set; }
		public DbSet<Discount> Discounts { get; set; }

		public DbSet<Product> Products { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
