using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
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

		public void Add(Car car)
		{
			if (car.DailyPrice>0)
			{
				_carDal.Add(car);
				Console.WriteLine("Araç başarıyla eklendi!");
			}
			else
			{
				Console.WriteLine("Araç fiyatı 0'dan büyük olmalıdır. Girilen Değer: {0}",car.DailyPrice);
			}
		}

		public void Delete(Car car)
		{
			_carDal.Delete(car);
			Console.WriteLine("{0} No'lu Araç Silindi", car.CarId);
		}

		public List<Car> GetAll()
		{
			return _carDal.GetAll();
		}

		public List<Car> GetAllByBrandId(int brandId)
		{
			return _carDal.GetAll(c => c.BrandId == brandId);
		}

		public List<Car> GetAllByColorId(int colorId)
		{
			return _carDal.GetAll(c => c.ColorId == colorId);
		}

		public List<Car> GetByDailyPrice(decimal min, decimal max)
		{
			return _carDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
		}

		public Car GetById(int CarId)
		{
			return _carDal.Get(c => c.CarId == CarId);
		}

		public List<Car> GetByModelYear(string modelYear)
		{
			return _carDal.GetAll(c => c.ModelYear == modelYear);
		}

		public void Update(Car car)
		{
			if (car.DailyPrice>0)
			{
				_carDal.Update(car);
				Console.WriteLine("{0} No'lu Araç Güncellendi!", car.CarId);
			}
			else
			{
				Console.WriteLine("Araç günlük fiyatı 0'dan büyük olmalıdır!!");
			}
			
		}
	}
}
