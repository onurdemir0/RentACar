using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
	public class InMemoryCarDal : ICarDal
	{
		List<Car> _cars;
		List<Brand> _brands;

		public InMemoryCarDal()
		{
			_cars = new List<Car>
			{
				new Car{CarId=1, BrandId=1,ColorId=1,DailyPrice=15000,Description="Dizel",ModelYear="2015"},
				new Car{CarId=2, BrandId=1,ColorId=3,DailyPrice=10000,Description="Dizel",ModelYear="2000"},
				new Car{CarId=3, BrandId=2,ColorId=4,DailyPrice=24000,Description="Benzinli",ModelYear="2018"},
				new Car{CarId=4, BrandId=2,ColorId=4,DailyPrice=18000,Description="Benzinli",ModelYear="2020"},
				new Car{CarId=5, BrandId=3,ColorId=2,DailyPrice=11000,Description="Dizel",ModelYear="2008"}
			};
			_brands = new List<Brand>
			{
				new Brand{BrandId=1,BrandName="Mercedes"},
				new Brand{BrandId=2,BrandName="Bmw"},
				new Brand{BrandId=3,BrandName="Audi"}
			};
		}

		public void Add(Car car)
		{
			_cars.Add(car);
		}

		public void Delete(Car car)
		{
			//LINQ
			Car carToDelete = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			_cars.Remove(carToDelete);
		}

		public List<Car> GetAll()
		{
			return _cars;
		}

		public List<Car> GetAllByBrand(int brandId)
		{
			return _cars.Where(c => c.BrandId == brandId).ToList();
		}

		public void Update(Car car) 
		{
			//LINQ
			Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
			carToUpdate.BrandId = car.BrandId;
			carToUpdate.ColorId = car.ColorId;
			carToUpdate.DailyPrice = car.DailyPrice;
			carToUpdate.Description = car.Description;
			carToUpdate.ModelYear = car.ModelYear;
		}
	}
}
