using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
	public class CarManager : ICarService
	{
		ICarDal _carDal;

		public CarManager(ICarDal carDal)
		{
			_carDal = carDal;
		}

		public IResult Add(Car car)
		{
			if (car.DailyPrice<=0)
			{
				return new ErrorResult(Messages.CarPriceInvalid);
			}
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		public IResult Delete(Car car) 
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		public IDataResult<List<Car>> GetAll()
		{
			if (DateTime.Now.Hour==22)
			{
				return new ErrorDataResult<List<Car>>(Messages.MaintenanTime);
			}
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetAllByBrandId(int brandId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId),Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetAllByColorId(int colorId)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId),Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsListed);
		}

		public IDataResult<Car> GetById(int CarId)
		{
			return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == CarId), Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetByModelYear(string modelYear)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear), Messages.CarsListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetails()
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarsListed);
		}

		public IResult Update(Car car)
		{
			if (car.DailyPrice<=0)
			{
				return new ErrorResult(Messages.CarPriceInvalid);
			}
			_carDal.Update(car);
			return new SuccessResult(Messages.CarUpdated);
		}
	}
}
