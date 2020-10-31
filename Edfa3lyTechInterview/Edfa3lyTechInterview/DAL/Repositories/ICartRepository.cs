using Edfa3lyTechInterview.BusinessLayer;
using Edfa3lyTechInterview.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edfa3lyTechInterview.DAL.Repositories
{
	internal interface ICartRepository
	{
		void DeleteCartItemByID(Guid cartItemID);

		IEnumerable<Cart> GetCartItems();

		void Save();

		DetailedBill SetTotalBill();
	}
}
