using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

/*
 * Context class which defines the DB and its tables
 */

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

		//Specifiy some conventions when the model is being created
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
		}
	}
}
