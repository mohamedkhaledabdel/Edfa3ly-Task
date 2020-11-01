using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

/*
 * Cart model that reperesnts the cart table, columns, and constrains in the DB
 */

namespace Edfa3lyTechInterview.Models
{
	public class Product
	{
		[Key]
		public Guid ID { get; set; }

		public string Name { get; set; }
		public double Price { get; set; }
	}
}
