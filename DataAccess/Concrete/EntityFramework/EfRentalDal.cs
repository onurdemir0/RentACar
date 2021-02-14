using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<RentACarContext, Rental>, IRentalDal
	{
		public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
							 join c in context.Cars on r.CarId equals c.CarId
							 join b in context.Brands on c.BrandId equals b.BrandId
							 join cu in context.Customers on r.CustomerId equals cu.Id
							 join u in context.Users on cu.UserId equals u.Id
							 select new RentalDetailDto
							 {
								 Id = r.Id,
								 BrandName = b.BrandName,
								 CompanyName = cu.CompanyName,
								 FirstName = u.FirstName,
								 LastName = u.LastName,
								 DailyPrice = c.DailyPrice,
								 RentDate = r.RentDate,
								 ReturnDate = r.ReturnDate
							 };
				return result.ToList();
			}
		}
	}
}
