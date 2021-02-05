using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
	public class BrandManager : IBrandService
	{
		IBrandDal _brandDal;

		public BrandManager(IBrandDal brandDal)
		{
			_brandDal = brandDal;
		}

		public void Add(Brand brand)
		{
			if (brand.BrandName.Length>2)
			{
				_brandDal.Add(brand);
				Console.WriteLine("{0} marka başarıyla eklendi",brand.BrandName);
			}
			else
			{
				Console.WriteLine("Marka isim uzunluğu 2'den büyük olmalıdır!");
			}
		}

		public void Delete(Brand brand)
		{
			_brandDal.Delete(brand);
			Console.WriteLine("Marka başarıyla silindi!");
		}

		public List<Brand> GetAll()
		{
			return _brandDal.GetAll();
		}

		public Brand GetById(int brandId)
		{
			return _brandDal.Get(b => b.BrandId == brandId);
		}

		public void Update(Brand brand)
		{
			if (brand.BrandName.Length>2)
			{
				_brandDal.Update(brand);
				Console.WriteLine("{0} marka başarıyla güncellendi",brand.BrandName);
			}
			else
			{
				Console.WriteLine("Marka isim uzunluğu 2'den büyük olmalıdır!");
			}
		}
	}
}
