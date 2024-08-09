using APW.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace APW.DataSource;

public interface IVehicleSource
{
    List<Car> Cars { get; set; }
    Car? FindCar(string id);
    Car? UpdateCar(Car car);
    IEnumerable<Car> AddCar(Car car);
    IEnumerable<Car> DeleteCar(string id);
}

public class CarSource : IVehicleSource
{
    public List<Car> Cars { get; set; } = GetVehicles();

    private static List<Car> GetVehicles() => [
        new Car { Id = new Guid("4e2d9b63-ff4d-4b92-b735-54fb03503498"), Brand = "Toyota", Model = "Corolla" },
        new Car { Id = new Guid("1f4e9a63-d54b-4c8d-b3a9-1c788ec6c9a0"), Brand = "Toyota", Model = "Camry" },
        new Car { Id = new Guid("a7f23b4e-452d-4729-9bcf-926f3582d62e"), Brand = "Honda", Model = "Civic" },
        new Car { Id = new Guid("0d529d4e-9ae4-47d1-a11a-ec7eaeae96f1"), Brand = "Honda", Model = "Accord" },
        new Car { Id = new Guid("5a1e4683-15d4-4705-97ea-9d487b6b9b60"), Brand = "Ford", Model = "Mustang" },
        new Car { Id = new Guid("6b8a6d25-17e9-418f-bb79-61239f746370"), Brand = "Ford", Model = "F-150" },
        new Car { Id = new Guid("7a98e2d7-82a5-49d1-8f5b-37de1e4f6c74"), Brand = "Chevrolet", Model = "Silverado" },
        new Car { Id = new Guid("8b0e4b3a-c6f2-4978-8329-9f5d0e31580f"), Brand = "Chevrolet", Model = "Malibu" },
        new Car { Id = new Guid("6d2b6e5f-87f1-4b99-91df-7c4e12f7b524"), Brand = "BMW", Model = "3 Series" },
        new Car { Id = new Guid("2b5e29b7-4b22-4fa1-bdf2-d129ec8f2567"), Brand = "BMW", Model = "X5" },
        new Car { Id = new Guid("9e8347a4-5c91-47c3-925e-b19d306d9f54"), Brand = "Mercedes-Benz", Model = "C-Class" },
        new Car { Id = new Guid("1c83d9f8-2a37-4f5c-a6a4-b3e9b3f8c0e2"), Brand = "Mercedes-Benz", Model = "E-Class" },
        new Car { Id = new Guid("7e3d5a8c-5f98-49fb-877b-0739f00b21a6"), Brand = "Audi", Model = "A4" },
        new Car { Id = new Guid("4d5e8c7a-1d5c-48b5-8129-f8b1c9f7d4e2"), Brand = "Audi", Model = "Q7" },
        new Car { Id = new Guid("3f8a92e3-9985-4b1e-9eb4-f4ed87e5d2b9"), Brand = "Tesla", Model = "Model S" },
        new Car { Id = new Guid("b2e5f798-2a7f-47e9-8e9e-29d7a9b3f8c7"), Brand = "Tesla", Model = "Model 3" },
        new Car { Id = new Guid("7d6f8a2b-4732-46c8-92f1-7e6a9d5e4f3a"), Brand = "Nissan", Model = "Altima" },
        new Car { Id = new Guid("2a7e5d3f-1c8b-4b2d-8329-6f8b7e5a9d3f"), Brand = "Nissan", Model = "Rogue" },
        new Car { Id = new Guid("6f2d3b4e-9981-4b6a-8379-2d7e4f5b6a3c"), Brand = "Hyundai", Model = "Elantra" },
        new Car { Id = new Guid("2c7a5d8f-4b8e-46d1-9f1e-8b7e9a2f7d6c"), Brand = "Hyundai", Model = "Tucson" }
        ];

    public Car? FindCar(string id)
    {
        return Cars.FirstOrDefault(car => car.Id.ToString() == id);
    }

    public Car? UpdateCar(Car car)
    {
        var existingCar = Cars.FirstOrDefault(c => c.Id == car.Id);
        if (existingCar != null)
        {
            existingCar.Brand = car.Brand;
            existingCar.Model = car.Model;
        }
        return existingCar;
    }


    public IEnumerable<Car> AddCar(Car car)
    {
        Cars.Add(car);
        return Cars;
    }

    public IEnumerable<Car> DeleteCar(string id)
    {
        Cars.RemoveAll(car => car.Id.ToString() == id);
        return Cars;
    }
}

//public class TrunkSource : IVehicleSource
//{
//    IEnumerable<Car> IVehicleSource.Cars => throw new NotImplementedException();

//    public IEnumerable<Car> GetVehicle()
//    {
//        //Debug.Assert();
//        //throw new NotImplementedException();

//#if DEBUG
//        Console.WriteLine("Im in debug mode");
//#endif

//        return default(Car[]);
//    }
//}