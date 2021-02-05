using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
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
			CarManager carManager = new CarManager(new EfCarDal());
			BrandManager brandManager = new BrandManager(new EfBrandDal());
			ColorManager colorManager = new ColorManager(new EfColorDal());

			//brandManager.Add(new Brand { BrandId = 7, BrandName = "O" });
			/*List<Color> colors = new List<Color> 
			{
				new Color { ColorId = 1, ColorName = "Siyah" },
				new Color { ColorId = 2, ColorName = "Beyaz" },
				new Color { ColorId = 3, ColorName = "Kırmızı" },
				new Color { ColorId = 4, ColorName = "Mor" },
				new Color { ColorId = 5, ColorName = "Yeşil" } 
			};
			foreach (Color color in colors)
			{
				colorManager.Add(color);
			}*/

			List<Car> cars = new List<Car>
			{
				new Car {CarId=2,BrandId=3,ColorId=1,DailyPrice=10000,ModelYear="2010",Description="Dizel"},
				new Car {CarId=3,BrandId=1,ColorId=4,DailyPrice=20000,ModelYear="2018",Description="Benzinli"},
				new Car {CarId=4,BrandId=5,ColorId=2,DailyPrice=12000,ModelYear="2013",Description="Dizel"},
				new Car {CarId=5,BrandId=2,ColorId=5,DailyPrice=14000,ModelYear="2020",Description="Elektrikli"},
				new Car {CarId=6,BrandId=4,ColorId=3,DailyPrice=30000,ModelYear="2000",Description="LPG"}
			};
			foreach (Car car in cars)
			{
				carManager.Add(car);
			}

			//carManager.Add(new Car { CarId = 1, BrandId = 1, ColorId = 5, DailyPrice = 20000, ModelYear = "2018", Description = "Benzinli" });

			Console.WriteLine("---Rent A Car--- \n\t\t\t Tüm Markalar\n");
			Console.WriteLine("Brand Id\tBrand Name");
			Console.WriteLine("--------\t----------");
			foreach (Brand brand in brandManager.GetAll())
			{
				Console.WriteLine("{0}\t\t{1}", brand.BrandId, brand.BrandName);
			}


			//InMemory();
		}

		private static void InMemory()
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
