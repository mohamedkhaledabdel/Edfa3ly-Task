using Edfa3lyTechInterview.DAL;
using Edfa3lyTechInterview.DAL.Repositories;
using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Edfa3lyTechInterview.Controllers
{
	public class ProductsController : ApiController
	{
		private IProductRepository productRepository;

		private ProductsController(IProductRepository productRepository)
		{
			this.productRepository = productRepository;
		}

		private ProductsController()
		{
			this.productRepository = new ProductRepository(new Context());
		}

		[HttpPost]
		[Route("api/product")]
		public HttpResponseMessage AddProduct(Product product)
		{
			product.ID = Guid.NewGuid();
			this.productRepository.InsertProduct(product);
			this.productRepository.Save();
			HttpResponseMessage responseMessage = Request.CreateResponse(System.Net.HttpStatusCode.OK, "Added product to DB successfully");
			return responseMessage;
		}

		//Get api/products
		[HttpGet]
		public HttpResponseMessage GetProducts()
		{
			HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, this.productRepository.GetProducts());
			return response;
		}
	}
}
