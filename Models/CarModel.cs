namespace reactnet_cars.Models
{
  public class CarModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int MakeId { get; set; }
    public CarMake Make { get; set; }
  }
}