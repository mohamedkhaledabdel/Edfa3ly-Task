using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edfa3lyTechInterview.DAL.Repositories
{
	internal interface IProductRepository
	{
		Product GetProductByID(int productID);

		IEnumerable<Product> GetProducts();

		void InsertProduct(Product product);

		void Save();
	}
}
