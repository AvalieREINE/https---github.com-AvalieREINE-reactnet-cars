using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using reactnet_cars.Dtos.CarMakes;
using reactnet_cars.Models;


namespace reactnet_cars.Services
{
  public class CarMakeService : ICarMakeService
  {

    // private readonly IMapper _mapper;

    // public CarMakeService(IMapper mapper)
    // {
    //   _mapper = mapper;

    // }
    public ServiceResponse<List<CarMake>> GetAllMakes()
    {
      var serviceResponse = new ServiceResponse<List<CarMake>>();
      serviceResponse.Data = getAllCarMakeFromSource();
      return serviceResponse;
    }

    public ServiceResponse<CarMake> GetMakeById(int id)
    {
      var serviceResponse = new ServiceResponse<CarMake>();
      List<CarMake> allCarMakes = getAllCarMakeFromSource();
      CarMake foundCar = allCarMakes.FirstOrDefault(c => c.Id == id);
      if (foundCar != null)
      {
        serviceResponse.Data = foundCar;
      }
      else
      {
        serviceResponse.Success = false;
        serviceResponse.Message = "Car make not found";
      }
      return serviceResponse;
    }
    public ServiceResponse<CarMake> CreateMake(CarMake newCarMake)
    {
      var serviceResponse = new ServiceResponse<CarMake>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\Makes.txt");
        List<CarMake> carMakes = new List<CarMake>();
        List<string> lines = File.ReadAllLines(path).ToList();
        string newEntry = $"{newCarMake.Id},{newCarMake.Name}";
        lines.Add(newEntry);
        File.WriteAllLines(path, lines);
        serviceResponse.Data = newCarMake;
      }
      catch (System.Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public ServiceResponse<List<CarMake>> UpdateCarMake(CarMake updatedCarMake)
    {
      var serviceResponse = new ServiceResponse<List<CarMake>>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\Makes.txt");
        string[] lines = File.ReadAllLines(path);
        string newEntry = $"{updatedCarMake.Id},{updatedCarMake.Name}";

        for (int i = 0; i < lines.Length; i++)
        {
          string[] entries = lines[i].Split(',');
          if (entries[0] == updatedCarMake.Id.ToString())
          {
            lines[i] = newEntry;
            break;
          }
          serviceResponse.Message = "Make not found.";
        }
        File.WriteAllLines(path, lines);


        serviceResponse.Data = getAllCarMakeFromSource();
      }
      catch (System.Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public ServiceResponse<List<CarMake>> RemoveMake(int id)
    {
      var serviceResponse = new ServiceResponse<List<CarMake>>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\Makes.txt");
        List<string> lines = File.ReadAllLines(path).ToList();
        foreach (string line in lines)
        {
          string[] entries = line.Split(',');
          if (entries[0] == id.ToString())
          {
            lines.Remove(line);
            break;
          }
          serviceResponse.Message = "Make not found.";
        }
        File.WriteAllLines(path, lines);
        serviceResponse.Data = getAllCarMakeFromSource();
      }
      catch (System.Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }
    private static List<CarMake> getAllCarMakeFromSource()
    {
      string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\Makes.txt");
      List<CarMake> carMakes = new List<CarMake>();
      List<string> lines = File.ReadAllLines(path).ToList();
      foreach (var line in lines)
      {
        string[] entries = line.Split(',');
        carMakes.Add(new CarMake { Id = Int32.Parse(entries[0]), Name = entries[1] });
      }
      return carMakes;
    }


  }


}

