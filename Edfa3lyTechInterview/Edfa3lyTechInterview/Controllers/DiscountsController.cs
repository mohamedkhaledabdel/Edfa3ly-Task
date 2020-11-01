using Edfa3lyTechInterview.DAL;
using Edfa3lyTechInterview.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

/*
 * DiscountssController class defines the REST API routes and their implementaion
 */

namespace Edfa3lyTechInterview.Controllers
{
	public class DiscountsController : ApiController
	{
		private IDiscountRepository discountRepository;

		private DiscountsController(IDiscountRepository discountRepository)
		{
			this.discountRepository = discountRepository;
		}

		private DiscountsController()
		{
			this.discountRepository = new DiscountRepository(new Context());
		}

		[Route("api/discounts/apply")]
		[HttpPut]
		public HttpResponseMessage CheckAndApplyDiscounts()
		{
			this.discountRepository.CheckForDiscounts();
			this.discountRepository.Save();
			HttpResponseMessage response = Request.CreateResponse(System.Net.HttpStatusCode.OK, "Applied Discounts successflly");
			return response;
		}
	}
}
