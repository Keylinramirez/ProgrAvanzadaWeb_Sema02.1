using APW.Architecture;
using Microsoft.AspNetCore.Mvc;
using PrograAvanzadaWeb_Sema02._1.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrograAvanzadaWeb_Sema02._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestController(IRestProvider restProvider) : ControllerBase
    {
        private readonly IRestProvider _restProvider = restProvider;

        // GET: api/<RestController>
        [HttpGet("all")]
        public async Task<object> GetAll()
        {
            var response = await _restProvider.GetAsync($"https://localhost:7154/api/Vehicle/", "all");
            return response;
        }

        // GET api/<RestController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(string id)
        {
            var response = await _restProvider.GetAsync($"https://localhost:7154/api/Vehicle/", id);
            return response;
        }

        // POST api/<RestController>
        [HttpPost]
        public async Task<string> Post([FromBody] CarViewModel car)
        {
            var response = await _restProvider.PostAsync($"https://localhost:7154/api/Vehicle/",
                JsonProvider.Serialize(CarViewModel.FromCarViewModelToCar(car)));
            return response;
        }

        // PUT api/<RestController>/5
        [HttpPut("{id}")]
        public async Task<string> Put([FromBody] CarViewModel car, string id)
        {
            var response = await _restProvider.PutAsync($"https://localhost:7154/api/Vehicle/", id,
                JsonProvider.Serialize(CarViewModel.FromCarViewModelToCar(car)));
            return response;
        }

        // DELETE api/<RestController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            var response = await _restProvider.DeleteAsync($"https://localhost:7154/api/Vehicle/", id);
            return response;
        }
    }
}
