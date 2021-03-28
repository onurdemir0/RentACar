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
		public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
		{
			using (RentACarContext context = new RentACarContext())
			{
				var result = from c in filter == null ? context.Cars : context.Cars.Where(filter)
							 join b in context.Brands 
							 on c.BrandId equals b.BrandId
							 join co in context.Colors 
							 on c.ColorId equals co.ColorId
							 join i in context.CarImages
							 on c.CarId equals i.CarId
							 select new CarDetailDto
							 {
								 CarId = c.CarId,
								 BrandName = b.BrandName,
								 ColorName = co.ColorName,
								 DailyPrice = c.DailyPrice,
								 ImagePath = i.ImagePath,
								 Description = c.Description,
								 ModelYear = c.ModelYear
							 };
				return result.ToList();
			}
		}
	}
}
