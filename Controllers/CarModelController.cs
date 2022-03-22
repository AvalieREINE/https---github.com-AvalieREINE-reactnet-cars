using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using reactnet_cars.Dtos.CarModels;
using reactnet_cars.Models;
using reactnet_cars.Services;

namespace reactnet_cars.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CarModelController : ControllerBase
  {


    private readonly ICarModelService _carModelService;
    public CarModelController(ICarModelService carModelService)
    {
      _carModelService = carModelService;

    }

    [HttpGet("GetAll")]
    public ActionResult<ServiceResponse<List<GetCarModelDto>>> GetAllCarModel()
    {
      return Ok(_carModelService.GetAllModels());
    }

    [HttpGet("{id}")]
    public ActionResult<ServiceResponse<GetCarModelDto>> GetCarMakeById(int id)
    {
      return Ok(_carModelService.GetModelById(id));
    }
    [HttpDelete("{id}")]
    public ActionResult<ServiceResponse<List<GetCarModelDto>>> RemoveCarModel(int id)
    {
      return Ok(_carModelService.RemoveModel(id));
    }
    [HttpPut]
    public ActionResult<ServiceResponse<GetCarModelDto>> UpdateCarModel(GetCarModelDto updatedCarModel)
    {
      return Ok(_carModelService.UpdateCarModel(updatedCarModel));
    }

    [HttpPost]
    public ActionResult<ServiceResponse<List<GetCarModelDto>>> CreateCarMake(GetCarModelDto newCarModel)
    {
      return Ok(_carModelService.CreateModelForSpecificMake(newCarModel));
    }
  }
}