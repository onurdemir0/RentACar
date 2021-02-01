using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
	class Program
	{
		static void Main(string[] args)
		{
			InMemoryCarDal inMemoryCarDal = new InMemoryCarDal();
			inMemoryCarDal.Add(new Car
			{
				CarId = 6,
				BrandId = 2,
				ColorId = 1,
				DailyPrice = 30000,
				Description = "Hybrid",
				ModelYear = "2021"
			});

			CarManager carManager = new CarManager(inMemoryCarDal);
			foreach (var car in carManager.GetAll())
			{
				Console.WriteLine(car.BrandId + " " + car.Description + " " + car.DailyPrice);
			}
			


			List<Brand> brands = new List<Brand>
			{
				new Brand{BrandId=1,BrandName="Mercedes"},
				new Brand{BrandId=2,BrandName="Bmw"},
				new Brand{BrandId=3,BrandName="Audi"}
			};

			List<Color> colors = new List<Color>
			{
				new Color{ColorId=1,ColorName="Beyaz"},
				new Color{ColorId=2,ColorName="Siyah"},
				new Color{ColorId=3,ColorName="Mor"},
				new Color{ColorId=4,ColorName="Kırmızı"}
			};
		}
	}
}
