using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*
 * DiscountRepository class implementing the IDiscountRepository interface.
 * Implements methods needed to access DB to query the discountstable
 */

namespace Edfa3lyTechInterview.DAL.Repositories
{
	public class DiscountRepository : IDiscountRepository
	{
		private Context context;
		private bool disposed = false;

		public DiscountRepository(Context context)
		{
			this.context = context;
		}

		//Apply discounts on a certain product based the parameters i.e product id and disocount rate
		public void ApplyDiscounts(Guid pid, int discountRate)
		{
			var cartItem = this.context.Carts.Where(item => item.ProductID == pid).FirstOrDefault<Cart>();
			cartItem.PriceOfCartItemAfterDiscount = cartItem.TotalPriceOfCartItem - (cartItem.TotalPriceOfCartItem * discountRate) / 100;
		}

		//Check for valid discounts on cart items and apply the discounts accordingly
		public void CheckForDiscounts()
		{
			foreach (Discount disc in context.Discounts)
			{
				if (((IEnumerable<Cart>)this.context.Carts.Where(item => item.ProductID == disc.OnProductID)).Any()
					&& ((IEnumerable<Cart>)this.context.Carts.Where(item => item.ProductID == disc.ProductID
					&& item.Quantity == disc.QuantityRequiredForDiscount)).Any())
				{
					this.ApplyDiscounts(disc.OnProductID, disc.DiscountPercentage);
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
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
