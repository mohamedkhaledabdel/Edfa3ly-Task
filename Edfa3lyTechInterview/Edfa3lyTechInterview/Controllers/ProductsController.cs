using Edfa3lyTechInterview.DAL;
using Edfa3lyTechInterview.DAL.Repositories;
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

		//Get api/products
		[HttpGet]
		public HttpResponseMessage GetProducts()
		{
			HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, this.productRepository.GetProducts());
			return response;
		}
	}
}
