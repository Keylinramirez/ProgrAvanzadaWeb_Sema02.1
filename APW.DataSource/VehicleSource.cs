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
    IEnumerable<Car> GetVehicle();
    IEnumerable<Car> Cars { get; }
}

public class CarSource : IVehicleSource
{
    public IEnumerable<Car> Cars => GetVehicle();

    public IEnumerable<Car> GetVehicle()
    {
        return
        [
            new Car { Id = Guid.NewGuid(), Brand = "Toyota", Model = "Corolla" },
            new Car { Id = Guid.NewGuid(), Brand = "Toyota", Model = "Camry" },
            new Car { Id = Guid.NewGuid(), Brand = "Honda", Model = "Civic" },
            new Car { Id = Guid.NewGuid(), Brand = "Honda", Model = "Accord" },
            new Car { Id = Guid.NewGuid(), Brand = "Ford", Model = "Mustang" },
            new Car { Id = Guid.NewGuid(), Brand = "Ford", Model = "F-150" },
            new Car { Id = Guid.NewGuid(), Brand = "Chevrolet", Model = "Silverado" },
            new Car { Id = Guid.NewGuid(), Brand = "Chevrolet", Model = "Malibu" },
            new Car { Id = Guid.NewGuid(), Brand = "BMW", Model = "3 Series" },
            new Car { Id = Guid.NewGuid(), Brand = "BMW", Model = "X5" },
            new Car { Id = Guid.NewGuid(), Brand = "Mercedes-Benz", Model = "C-Class" },
            new Car { Id = Guid.NewGuid(), Brand = "Mercedes-Benz", Model = "E-Class" },
            new Car { Id = Guid.NewGuid(), Brand = "Audi", Model = "A4" },
            new Car { Id = Guid.NewGuid(), Brand = "Audi", Model = "Q7" },
            new Car { Id = Guid.NewGuid(), Brand = "Tesla", Model = "Model S" },
            new Car { Id = Guid.NewGuid(), Brand = "Tesla", Model = "Model 3" },
            new Car { Id = Guid.NewGuid(), Brand = "Nissan", Model = "Altima" },
            new Car { Id = Guid.NewGuid(), Brand = "Nissan", Model = "Rogue" },
            new Car { Id = Guid.NewGuid(), Brand = "Hyundai", Model = "Elantra" },
            new Car { Id = Guid.NewGuid(), Brand = "Hyundai", Model = "Tucson" }
        ];
    }

    public bool AddCar(Car car)
    { 
        //var templist = Cars.ToList();

        if (car == null) 
            return false;

        Cars.ToList().Add(car);
        return true;
    }
}

public class TrunkSource : IVehicleSource
{
    IEnumerable<Car> IVehicleSource.Cars => throw new NotImplementedException();

    public IEnumerable<Car> GetVehicle()
    {
        //Debug.Assert();
        //throw new NotImplementedException();

#if DEBUG
        Console.WriteLine("Im in debug mode");
#endif

        return default(Car[]);
    }
}