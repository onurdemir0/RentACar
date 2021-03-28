using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
	public interface ICarService
	{
		IResult Add(Car car);
		IResult Delete(Car car);
		IResult Update(Car car);
		IDataResult<List<Car>> GetAll();
		IDataResult<Car> GetById(int CarId);
		IDataResult<List<Car>> GetAllByBrandId(int brandId);
		IDataResult<List<Car>> GetAllByColorId(int colorId);
		IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
		IDataResult<List<Car>> GetByModelYear(string modelYear);
		IDataResult<List<CarDetailDto>> GetCarDetails();
		IDataResult<List<CarDetailDto>> GetCarDetailsById(int carId);
		IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId);
		IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId);
		IResult AddTransactionalTest(Car car);
	}
}
