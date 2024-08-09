using APW.DataSource;
using APW.Models;
using Microsoft.AspNetCore.Mvc;
using PrograAvanzadaWeb_Sema02._1.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrograAvanzadaWeb_Sema02._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController(IVehicleSource vehicleSource) : ControllerBase
    {
        private readonly IVehicleSource _vehicleSource = vehicleSource;

        // GET: api/<VehicleController>
        [HttpGet("all")]
        public IEnumerable<CarViewModel> GetAll()
        {
            var cars = _vehicleSource.Cars.Select(car => new CarViewModel
            {
                Id = car.ToString(),
                Brand = car.Brand,
                Model = car.Model
            });
            return cars;
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public CarViewModel? Get(string id)
        {
            var car = _vehicleSource.FindCar(id);
            if (car != null)
            {
                return new CarViewModel
                {
                    Id = car.ToString(),
                    Brand = car.Brand,
                    Model = car.Model
                };
            }
            return null;
        }

        // POST api/<VehicleController>
        [HttpPost]
        public IEnumerable<CarViewModel> Post([FromBody] CarViewModel carViewModel)
        {
            var car = new Car
            {
                Id = Guid.NewGuid(),
                Brand = carViewModel.Brand,
                Model = carViewModel.Model,
            };
            _vehicleSource.AddCar(car);
            return GetAll();
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public CarViewModel? Put(string id, [FromBody] CarViewModel carViewModel)
        {
            var existingCar = _vehicleSource.FindCar(id);
            if (existingCar != null)
            {
                existingCar.Brand = carViewModel.Brand;
                existingCar.Model = carViewModel.Model;
                _vehicleSource.UpdateCar(existingCar);
                return new CarViewModel
                {
                    Id = existingCar.Id.ToString(),
                    Brand = existingCar.Brand,
                    Model = existingCar.Model
                };
            }
            return null;
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public IEnumerable<CarViewModel> Delete(string id)
        {
            _vehicleSource.DeleteCar(id);
            return GetAll();
        }
    }
}
