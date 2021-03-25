using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
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

		[SecuredOperation("car.add,admin")]
		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
		public IResult Add(Car car)
		{
			_carDal.Add(car);
			return new SuccessResult(Messages.CarAdded);
		}

		[TransactionScopeAspect]
		public IResult AddTransactionalTest(Car car)
		{
			throw new NotImplementedException();
		}

		[ValidationAspect(typeof(CarValidator))]
		public IResult Delete(Car car) 
		{
			_carDal.Delete(car);
			return new SuccessResult(Messages.CarDeleted);
		}

		[CacheAspect] //key, value
		[PerformanceAspect(5)]
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

		public IDataResult<List<CarDetailDto>> GetCarDetailsByBrandId(int brandId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByBrandDetails(brandId), Messages.CarsListed);
		}

		public IDataResult<List<CarDetailDto>> GetCarDetailsByColorId(int colorId)
		{
			return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetByColorDetails(colorId), Messages.CarsListed);
		}

		public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
		{
			return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max), Messages.CarsListed);
		}

		[CacheAspect]
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

		[ValidationAspect(typeof(CarValidator))]
		[CacheRemoveAspect("ICarService.Get")]
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
