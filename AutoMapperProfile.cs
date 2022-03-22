using AutoMapper;
using reactnet_cars.Dtos.CarMakes;
using reactnet_cars.Models;

namespace reactnet_cars
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<CarMake, GetCarMakeDto>();
    }
  }
}