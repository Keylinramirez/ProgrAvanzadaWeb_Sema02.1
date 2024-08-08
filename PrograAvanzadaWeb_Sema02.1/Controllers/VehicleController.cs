using APW.DataSource;
using APW.Models;
using Microsoft.AspNetCore.Mvc;
using PrograAvanzadaWeb_Sema02._1.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrograAvanzadaWeb_Sema02._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleSource _vehicleSource;

        public VehicleController(IVehicleSource vehicleSource) => _vehicleSource = vehicleSource;

        // GET: api/<VehicleController>
        [HttpGet]
        public IEnumerable<CarViewModel> Get()
        {
            return _vehicleSource.Cars.Select(c => new CarViewModel
            {
                Id = c.Guid,
                Brand = c.Brand,
                Model = c.Model,
                RegisteredTime = DateTime.Now,
            });
        }

        // GET api/<VehicleController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VehicleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VehicleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VehicleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
