using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using reactnet_cars.Dtos.CarModels;
using reactnet_cars.Models;

namespace reactnet_cars.Services
{
  public class CarModelService : ICarModelService
  {
    private readonly IMapper _mapper;
    public CarModelService(IMapper mapper)
    {
      _mapper = mapper;

    }
    public ServiceResponse<List<GetCarModelDto>> CreateModelForSpecificMake(GetCarModelDto newModel)
    {
      var serviceResponse = new ServiceResponse<List<GetCarModelDto>>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\models.txt");
        List<string> lines = File.ReadAllLines(path).ToList();
        string newEntry = $"{newModel.Id},{newModel.Name},{newModel.MakeId}";
        lines.Add(newEntry);
        File.WriteAllLines(path, lines);
        serviceResponse.Data = getAllCarModelFromSource().Select(c => _mapper.Map<GetCarModelDto>(c)).ToList();
      }
      catch (System.Exception ex)
      {
        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public ServiceResponse<GetCarModelDto> GetModelById(int id)
    {
      var serviceResponse = new ServiceResponse<GetCarModelDto>();
      List<GetCarModelDto> allCarModels = getAllCarModelFromSource();
      GetCarModelDto foundCar = allCarModels.FirstOrDefault(c => c.Id == id);
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

    public ServiceResponse<List<GetCarModelDto>> UpdateCarModel(GetCarModelDto updatedCarModel)
    {
      var serviceResponse = new ServiceResponse<List<GetCarModelDto>>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\models.txt");
        string[] lines = File.ReadAllLines(path);
        string newEntry = $"{updatedCarModel.Id},{updatedCarModel.Name},{updatedCarModel.MakeId}";

        for (int i = 0; i < lines.Length; i++)
        {
          string[] entries = lines[i].Split(',');
          if (entries[0] == updatedCarModel.Id.ToString())
          {
            lines[i] = newEntry;
            break;
          }
          serviceResponse.Message = "Make not found.";
        }
        File.WriteAllLines(path, lines);


        serviceResponse.Data = getAllCarModelFromSource().Select(c => _mapper.Map<GetCarModelDto>(c)).ToList();
      }
      catch (System.Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public ServiceResponse<List<GetCarModelDto>> RemoveModel(int id)
    {
      var serviceResponse = new ServiceResponse<List<GetCarModelDto>>();
      try
      {
        string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\models.txt");
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
        serviceResponse.Data = getAllCarModelFromSource().Select(c => _mapper.Map<GetCarModelDto>(c)).ToList();
      }
      catch (System.Exception ex)
      {

        serviceResponse.Success = false;
        serviceResponse.Message = ex.Message;
      }
      return serviceResponse;
    }

    public ServiceResponse<List<GetCarModelDto>> GetAllModels()
    {
      var serviceResponse = new ServiceResponse<List<GetCarModelDto>>();
      serviceResponse.Data = getAllCarModelFromSource().Select(c => _mapper.Map<GetCarModelDto>(c)).ToList();
      return serviceResponse;
    }


    private static List<GetCarModelDto> getAllCarModelFromSource()
    {
      string path = Path.Combine(Environment.CurrentDirectory, "DataSource\\models.txt");
      List<GetCarModelDto> carModels = new List<GetCarModelDto>();
      List<string> lines = File.ReadAllLines(path).ToList();
      foreach (var line in lines)
      {
        string[] entries = line.Split(',');
        carModels.Add(new GetCarModelDto { Id = Int32.Parse(entries[0]), Name = entries[1], MakeId = Int32.Parse(entries[2]) });
      }
      return carModels;
    }

  }
}