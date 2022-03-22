using System.Collections.Generic;
using reactnet_cars.Dtos.CarModels;
using reactnet_cars.Models;

namespace reactnet_cars.Services
{
  public interface ICarModelService
  {
    ServiceResponse<List<GetCarModelDto>> GetAllModels();
    ServiceResponse<GetCarModelDto> GetModelById(int id);
    ServiceResponse<List<GetCarModelDto>> CreateModelForSpecificMake(GetCarModelDto newModel);
    ServiceResponse<List<GetCarModelDto>> UpdateCarModel(GetCarModelDto updatedCarModel);
    ServiceResponse<List<GetCarModelDto>> RemoveModel(int id);
  }
}