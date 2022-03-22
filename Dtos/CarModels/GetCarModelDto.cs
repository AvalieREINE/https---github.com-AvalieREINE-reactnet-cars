using reactnet_cars.Models;

namespace reactnet_cars.Dtos.CarModels
{
  public class GetCarModelDto
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int MakeId { get; set; }
  }
}