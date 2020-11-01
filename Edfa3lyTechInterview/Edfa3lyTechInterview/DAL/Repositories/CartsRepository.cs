using Edfa3lyTechInterview.BusinessLayer;
using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * CartRepository class implementing the ICartRepository interface.
 * Implements methods needed to access DB to query the carts table
 */

namespace Edfa3lyTechInterview.DAL.Repositories
{
	public class CartsRepository : ICartRepository
	{
		public double Taxes = 0;
		public double TotalBill = 0;
		public double TotalBillDiscount = 0;

		private Context context;
		private bool disposed = false;

		public CartsRepository(Context context)
		{
			this.context = context;
		}

		//Delete a car item by its ID
		public void DeleteCartItemByID(Guid cartItemID)
		{
			var cart = this.context.Carts.Find(cartItemID);
			this.context.Carts.Remove(cart);
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		//Returns a list of all cart items
		public IEnumerable<Cart> GetCartItems()
		{
			return (IEnumerable<Cart>)this.context.Carts.ToList<Cart>();
		}

		public void Save()
		{
			context.SaveChanges();
		}

		//Return bill object that defines all details of a bill of a cart
		public DetailedBill SetTotalBill()
		{
			DetailedBill bill = new DetailedBill();
			foreach (Cart item in this.context.Carts.ToList<Cart>())
			{
				Console.WriteLine("item {0} original price is {1} and price after discount is {2}", item.Product.Name, item.TotalPriceOfCartItem
						, item.PriceOfCartItemAfterDiscount);
				TotalBill += item.TotalPriceOfCartItem;
				TotalBillDiscount += item.PriceOfCartItemAfterDiscount;
			}
			Taxes = (TotalBill * 14) / 100;
			//Console.WriteLine("Total bill is {0}", TotalBill);
			bill.TotalBill = this.TotalBill;
			Console.WriteLine("Taxes amount is {0}", Taxes);
			bill.Tax = this.Taxes;
			//Console.WriteLine("Total bill after discount is {0}", TotalBillDiscount);
			bill.TotalBillAfterDiscount = this.TotalBillDiscount;
			//Console.WriteLine("Final bill to be payed is {0}", Taxes + TotalBillDiscount);
			bill.FinalBill = this.Taxes + this.TotalBillDiscount;
			return bill;
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
