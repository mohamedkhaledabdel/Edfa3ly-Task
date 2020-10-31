using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Edfa3lyTechInterview.DAL
{
	public class ContextSeedInitializer : CreateDatabaseIfNotExists<Context>
	{
		public void SeedCall(Context context)
		{
			this.Seed(context);
		}

		protected override void Seed(Context context)
		{
			Product p1 = new Product
			{
				ID = Guid.NewGuid(),
				Name = "Shirt",
				Price = 10.99
			};
			Product p2 = new Product
			{
				ID = Guid.NewGuid(),
				Name = "Shoes",
				Price = 24.99
			};
			Product p3 = new Product
			{
				ID = Guid.NewGuid(),
				Name = "Jacket",
				Price = 19.99
			};
			context.Products.Add(p1);
			context.Products.Add(p2);
			context.Products.Add(p3);
			context.SaveChanges();
			Discount d1 = new Discount
			{
				ID = Guid.NewGuid(),
				OnProduct = p2,
				OnProductID = p2.ID,
				Product = p2,
				ProductID = p2.ID,
				DiscountPercentage = 10,
				QuantityRequiredForDiscount = 1
			};
			Discount d2 = new Discount
			{
				ID = Guid.NewGuid(),
				OnProduct = p3,
				OnProductID = p3.ID,
				Product = p1,
				ProductID = p1.ID,
				DiscountPercentage = 50,
				QuantityRequiredForDiscount = 2
			};
			context.Discounts.Add(d1);
			context.Discounts.Add(d2);
			context.SaveChanges();
		}
	}
}
