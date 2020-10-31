using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edfa3lyTechInterview.DAL.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private Context context;

		private bool disposed = false;

		public ProductRepository(Context context)
		{
			this.context = context;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		public Product GetProductByID(int productID)
		{
			return this.context.Products.Find(productID);
		}

		public IEnumerable<Product> GetProducts()
		{
			return this.context.Products.ToList<Product>();
		}

		public void InsertProduct(Product product)
		{
			this.context.Products.Add(product);
		}

		public void Save()
		{
			context.SaveChanges();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					context.Dispose();
				}
			}
			this.disposed = true;
		}
	}
}
