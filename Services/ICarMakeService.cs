using System.Collections.Generic;
using System.Threading.Tasks;
using reactnet_cars.Dtos.CarMakes;
using reactnet_cars.Models;

namespace reactnet_cars.Services
{
  public interface ICarMakeService
  {
    ServiceResponse<List<CarMake>> GetAllMakes();
    ServiceResponse<CarMake> GetMakeById(int id);
    ServiceResponse<CarMake> CreateMake(CarMake newMake);
    ServiceResponse<List<CarMake>> UpdateCarMake(CarMake updateCarMake);
    ServiceResponse<List<CarMake>> RemoveMake(int id);

  }
}