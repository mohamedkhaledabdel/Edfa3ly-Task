using Edfa3lyTechInterview.BusinessLayer;
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

/*
 * CartsController class defines the REST API routes and their implementaion
 */

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
			DetailedBill bill = this.cartRepository.SetTotalBill();
			string JSON = JsonConvert.SerializeObject(bill);
			HttpResponseMessage response;
			if (bill.TotalBillAfterDiscount == bill.TotalBill)
			{
				bill.FinalBill = bill.FinalBill * 15.6;
			}
			response = Request.CreateResponse(System.Net.HttpStatusCode.OK, bill);
			return response;
		}
	}
}
