using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

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
			}

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
			}*/
			//carManager.Update(new Car { CarId = 3, BrandId = 1, ColorId = 4, DailyPrice = 40000, ModelYear = "2021", Description = "Turbo Benzinli" });

			AllCarDetailDto(carManager);

			AllBrands(brandManager);

			AllCars(carManager, brandManager, colorManager);

			FilterPrice(carManager, brandManager, colorManager);

			FilterColor(carManager, brandManager, colorManager);

			FilterBrand(carManager, brandManager, colorManager);

			//InMemory();
		}

		private static void AllCarDetailDto(CarManager carManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Tüm Araçlar\n");
			Console.WriteLine("Car Id\tBrand\t\tColor\t\tPrice");
			Console.WriteLine("------\t-----\t\t-----\t\t-----");
			foreach (CarDetailDto car in carManager.GetCarDetails())
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}",
					car.CarId,
					car.BrandName,
					car.ColorName,
					car.DailyPrice);
			}
		}

		private static void FilterBrand(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Filter: Brand[Audi]\n");
			Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
			Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
			foreach (Car car in carManager.GetAllByBrandId(1))
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
					car.CarId,
					brandManager.GetById(car.BrandId).BrandName,
					colorManager.GetById(car.ColorId).ColorName,
					car.ModelYear,
					car.DailyPrice,
					car.Description);
			}
		}

		private static void FilterColor(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Filter: Color[Yeşil]\n");
			Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
			Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
			foreach (Car car in carManager.GetAllByColorId(5))
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
					car.CarId,
					brandManager.GetById(car.BrandId).BrandName,
					colorManager.GetById(car.ColorId).ColorName,
					car.ModelYear,
					car.DailyPrice,
					car.Description);
			}
		}

		private static void FilterPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Filter: Price[10000-15000]\n");
			Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
			Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
			foreach (Car car in carManager.GetByDailyPrice(10000, 15000))
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
					car.CarId,
					brandManager.GetById(car.BrandId).BrandName,
					colorManager.GetById(car.ColorId).ColorName,
					car.ModelYear,
					car.DailyPrice,
					car.Description);
			}
		}

		private static void AllBrands(BrandManager brandManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Tüm Markalar\n");
			Console.WriteLine("Brand Id\tBrand Name");
			Console.WriteLine("--------\t----------");
			foreach (Brand brand in brandManager.GetAll().OrderBy(b=>b.BrandName))
			{
				Console.WriteLine("{0}\t\t{1}", brand.BrandId, brand.BrandName);
			}
		}

		private static void AllCars(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			Console.WriteLine("\n---Rent A Car--- \t\t Tüm Araçlar\n");
			Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
			Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
			foreach (Car car in carManager.GetAll().OrderBy(c=>c.DailyPrice))
			{
				Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
					car.CarId,
					brandManager.GetById(car.BrandId).BrandName,
					colorManager.GetById(car.ColorId).ColorName,
					car.ModelYear,
					car.DailyPrice,
					car.Description);
			}
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
