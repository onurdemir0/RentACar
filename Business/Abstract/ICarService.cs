using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		void Add(Car car);
		void Delete(Car car);
		void Update(Car car);
		List<Car> GetAll();
		Car GetById(int CarId);
		List<Car> GetAllByBrandId(int brandId);
		List<Car> GetAllByColorId(int colorId);
		List<Car> GetByDailyPrice(decimal min, decimal max);
		List<Car> GetByModelYear(string modelYear);
		List<CarDetailDto> GetCarDetails();
	}
}
