using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * ProductRepository class implementing the IProductRepository interface.
 * Implements methods needed to access DB to query the products table
 */

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

		//Method takes as a parameter a productID and returns a product object
		public Product GetProductByID(int productID)
		{
			return this.context.Products.Find(productID);
		}

		//Return a list of all producs
		public IEnumerable<Product> GetProducts()
		{
			return this.context.Products.ToList<Product>();
		}

		//Takes as an input a Product object and insert it to the DB
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
