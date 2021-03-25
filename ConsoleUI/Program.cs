using Business.Concrete;
using Core.Entities.Concrete;
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
			UserManager userManager = new UserManager(new EfUserDal());
			CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
			RentalManager rentalManager = new RentalManager(new EfRentalDal());

			//ColorAdd(colorManager);
			//CarAdd(carManager);
			//carManager.Update(new Car { CarId = 3, BrandId = 1, ColorId = 4, DailyPrice = 40001, ModelYear = "2021", Description = "Turbo Benzinli" });
			//UserAdd(userManager);
			//CustomerAdd(customerManager);
			//RentAdd(rentalManager);

			rentalManager.Add(new Rental { CarId = 5, CustomerId = 4, RentDate = new DateTime(2020, 04, 15) });


			//AllRentDetailDto(rentalManager);

			//AllCarDetailDto(carManager);

			//AllBrands(brandManager);

			//AllCars(carManager, brandManager, colorManager);

			//FilterPrice(carManager, brandManager, colorManager);

			//FilterColor(carManager, brandManager, colorManager);

			//FilterBrand(carManager, brandManager, colorManager);

			//InMemory();
		}

		private static void AllRentDetailDto(RentalManager rentalManager)
		{
			var result = rentalManager.GetAllRent();
			if (result.Success == true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Tüm Kiralamalar\n");
				Console.WriteLine("Id\tBrand\t\tCompany\t\tName\t\tSurName\t\tPrice\t\tRentDate\t\tReturnDate");
				Console.WriteLine("--\t-----\t\t-------\t\t----\t\t-------\t\t-----\t\t--------\t\t----------");
				foreach (RentalDetailDto rent in result.Data)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t\t{6}\t{7}",
						rent.Id,
						rent.BrandName,
						rent.CompanyName,
						rent.FirstName,
						rent.LastName,
						rent.DailyPrice,
						rent.RentDate,
						rent.ReturnDate);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void RentAdd(RentalManager rentalManager)
		{
			List<Rental> rentals = new List<Rental>
			{
				new Rental { CarId=5,CustomerId=1,RentDate=new DateTime(2020,04,15) },
				new Rental { CarId=3,CustomerId=5,RentDate=new DateTime(2020,06,22) },
				new Rental { CarId=4,CustomerId=2,RentDate=new DateTime(2020,08,17) }
			};
			foreach (Rental rental in rentals)
			{
				rentalManager.Add(rental);
			}
		}

		private static void CustomerAdd(CustomerManager customerManager)
		{
			List<Customer> customers = new List<Customer>
			{
				new Customer { UserId=2,CompanyName="Turkcell" },
				new Customer { UserId=5,CompanyName="Tesla" },
				new Customer { UserId=1,CompanyName="Apple"},
				new Customer { UserId=4,CompanyName="Google" }
			};
			foreach (Customer customer in customers)
			{
				customerManager.Add(customer);
			}
		}

		private static void UserAdd(UserManager userManager)
		{
			List<User> users = new List<User>
			{
				new User { FirstName="Leyla",LastName="Gün",Email="agdf4yh@gmail.com"},
				new User { FirstName="Sıla",LastName="Demir",Email="nnngsa@gmail.com"},
				new User { FirstName="Kaan",LastName="Çelik",Email="asanjk@gmail.com"},
				new User { FirstName="Ali",LastName="Sevgi",Email="gg555dd@gmail.com"}
			};
			foreach (User user in users)
			{
				userManager.Add(user);
			}
		}

		private static void ColorAdd(ColorManager colorManager)
		{
			List<Color> colors = new List<Color>
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
		}

		private static void CarAdd(CarManager carManager)
		{
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
		}

		private static void AllCarDetailDto(CarManager carManager)
		{
			var result = carManager.GetCarDetails();
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Tüm Araçlar\n");
				Console.WriteLine("Car Id\tBrand\t\tColor\t\tPrice");
				Console.WriteLine("------\t-----\t\t-----\t\t-----");
				foreach (CarDetailDto car in result.Data)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}",
						car.CarId,
						car.BrandName,
						car.ColorName,
						car.DailyPrice);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void FilterBrand(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			var result = carManager.GetAllByBrandId(1);
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Filter: Brand[Audi]\n");
				Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
				Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
				foreach (Car car in result.Data)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
						car.CarId,
						brandManager.GetById(car.BrandId).Data.BrandName,
						colorManager.GetById(car.ColorId).Data.ColorName,
						car.ModelYear,
						car.DailyPrice,
						car.Description);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void FilterColor(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			var result = carManager.GetAllByColorId(5);
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Filter: Color[Yeşil]\n");
				Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
				Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
				foreach (Car car in result.Data)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
						car.CarId,
						brandManager.GetById(car.BrandId).Data.BrandName,
						colorManager.GetById(car.ColorId).Data.ColorName,
						car.ModelYear,
						car.DailyPrice,
						car.Description);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void FilterPrice(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			var result = carManager.GetByDailyPrice(10000, 15000);
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Filter: Price[10000-15000]\n");
				Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
				Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
				foreach (Car car in result.Data)
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
						car.CarId,
						brandManager.GetById(car.BrandId).Data.BrandName,
						colorManager.GetById(car.ColorId).Data.ColorName,
						car.ModelYear,
						car.DailyPrice,
						car.Description);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void AllBrands(BrandManager brandManager)
		{
			var result = brandManager.GetAll();
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Tüm Markalar\n");
				Console.WriteLine("Brand Id\tBrand Name");
				Console.WriteLine("--------\t----------");
				foreach (Brand brand in result.Data.OrderBy(b => b.BrandName))
				{
					Console.WriteLine("{0}\t\t{1}", brand.BrandId, brand.BrandName);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
			}
		}

		private static void AllCars(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
		{
			var result = carManager.GetAll();
			if (result.Success==true)
			{
				Console.WriteLine("\n---Rent A Car--- \t\t Tüm Araçlar\n");
				Console.WriteLine("Car Id\tBrand\t\tColor\t\tModel\t\tPrice\tDescription");
				Console.WriteLine("------\t-----\t\t-----\t\t-----\t\t-----\t-----------");
				foreach (Car car in result.Data.OrderBy(c => c.DailyPrice))
				{
					Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",
						car.CarId,
						brandManager.GetById(car.BrandId).Data.BrandName,
						colorManager.GetById(car.ColorId).Data.ColorName,
						car.ModelYear,
						car.DailyPrice,
						car.Description);
				}
			}
			else
			{
				Console.WriteLine(result.Message);
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
			foreach (var car in carManager.GetAll().Data)
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
