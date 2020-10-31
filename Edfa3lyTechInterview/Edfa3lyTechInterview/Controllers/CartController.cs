using Edfa3lyTechInterview.DAL;
using Edfa3lyTechInterview.DAL.Repositories;
using Edfa3lyTechInterview.Models;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Edfa3lyTechInterview.Controllers
{
	public class CartsController : ApiController
	{
		private ICartRepository cartRepository;

		private CartsController(ICartRepository cartRepository)
		{
			this.cartRepository = cartRepository;
		}

		private CartsController()
		{
			this.cartRepository = new CartsRepository(new DAL.Context());
		}

		//Get api/carts
		[HttpGet]
		public HttpResponseMessage GetCartItems()
		{
			HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, this.cartRepository.GetCartItems());
			return response;
		}

		//Get api/detailedBill
		[Route("api/carts/detailedBill")]
		[HttpGet]
		public HttpResponseMessage GetDetailedBill()
		{
			string JSON = JsonConvert.SerializeObject(this.cartRepository.SetTotalBill());
			HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, JSON);
			return response;
		}
	}
}
