using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reactnet_cars.Models;
using reactnet_cars.Services;

namespace reactnet_cars.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CarMakeController : ControllerBase
  {
    private readonly ICarMakeService _carMakeService;
    public CarMakeController(ICarMakeService carMakeService)
    {
      _carMakeService = carMakeService;

    }

    [HttpGet("GetAll")]
    public ActionResult<ServiceResponse<List<CarMake>>> GetAllCarMake()
    {
      return Ok(_carMakeService.GetAllMakes());
    }
    [HttpGet("{id}")]
    public ActionResult<ServiceResponse<CarMake>> GetCarMakeById(int id)
    {
      return Ok(_carMakeService.GetMakeById(id));
    }

    [HttpPost]
    public ActionResult<ServiceResponse<CarMake>> CreateCarMake(CarMake newCarMake)
    {
      return Ok(_carMakeService.CreateMake(newCarMake));
    }
    [HttpPut]
    public ActionResult<ServiceResponse<CarMake>> UpdateCarMake(CarMake updatedCarMake)
    {
      return Ok(_carMakeService.UpdateCarMake(updatedCarMake));
    }
    [HttpDelete("{id}")]
    public ActionResult<ServiceResponse<List<CarMake>>> RemoveCarMake(int id)
    {
      return Ok(_carMakeService.RemoveMake(id));
    }
  }
}