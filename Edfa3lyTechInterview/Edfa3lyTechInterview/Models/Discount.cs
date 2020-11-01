using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

/*
 * Cart model that reperesnts the cart table, columns, and constrains in the DB
 */

namespace Edfa3lyTechInterview.Models
{
	public class Discount
	{
		public int DiscountPercentage { get; set; }

		[Key]
		public Guid ID { get; set; }

		public virtual Product OnProduct { get; set; }

		public Guid OnProductID { get; set; }

		//Using virtual keyword will cause the category object itself to be returned with other properties.
		//This concept is called lazy loading

		public virtual Product Product { get; set; }

		[ForeignKey("Product")]
		[Display(Name = "ProductID")]
		public Guid ProductID { get; set; }

		public int QuantityRequiredForDiscount { get; set; }
	}
}
