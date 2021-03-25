using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CarsController : ControllerBase
	{
		ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("getall")]
		public IActionResult GetAll()
		{
			var result = _carService.GetAll();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbyid")]
		public IActionResult GetById(int id)
		{
			var result = _carService.GetById(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getallbybrandid")]
		public IActionResult GetAllByBrandId(int id)
		{
			var result = _carService.GetAllByBrandId(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getallbycolorid")]
		public IActionResult GetAllByColorId(int id)
		{
			var result = _carService.GetAllByColorId(id);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbydailyprice")]
		public IActionResult GetByDailyPrice(decimal min, decimal max)
		{
			var result = _carService.GetByDailyPrice(min, max);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getbymodelyear")]
		public IActionResult GetByModelYear(string modelYear)
		{
			var result = _carService.GetByModelYear(modelYear);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
		
		[HttpGet("getcardetails")]
		public IActionResult GetCarDetails()
		{
			var result = _carService.GetCarDetails();
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcardetailsbybrandid")]
		public IActionResult GetCarDetailsByBrandId(int brandId)
		{
			var result = _carService.GetCarDetailsByBrandId(brandId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpGet("getcardetailsbycolorid")]
		public IActionResult GetCarDetailsByColorId(int colorId)
		{
			var result = _carService.GetCarDetailsByColorId(colorId);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("add")]
		public IActionResult Add(Car car)
		{
			var result = _carService.Add(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("update")]
		public IActionResult Update(Car car)
		{
			var result = _carService.Update(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}

		[HttpPost("delete")]
		public IActionResult Delete(Car car)
		{
			var result = _carService.Delete(car);
			if (result.Success)
			{
				return Ok(result);
			}
			return BadRequest(result);
		}
	}
}
