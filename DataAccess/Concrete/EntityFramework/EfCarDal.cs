using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfCarDal : EfEntityRepositoryBase<RentACarContext, Car>, ICarDal
	{
		public List<CarDetailDto> GetCarDetails()
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from c in context.Cars
							 join b in context.Brands 
							 on c.BrandId equals b.BrandId
							 join co in context.Colors 
							 on c.ColorId equals co.ColorId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice
							 };
				return result.ToList();
			}
		}
	}
}
