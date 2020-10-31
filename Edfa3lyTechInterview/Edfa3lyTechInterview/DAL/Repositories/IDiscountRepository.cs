using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edfa3lyTechInterview.DAL.Repositories
{
	internal interface IDiscountRepository
	{
		void ApplyDiscounts(Guid onPid, int discountRate);

		void CheckForDiscounts();

		void Save();
	}
}
