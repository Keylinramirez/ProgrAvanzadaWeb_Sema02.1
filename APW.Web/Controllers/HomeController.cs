using APW.Architecture;
using APW.Web.Models;
using Microsoft.AspNetCore.Mvc;
using PrograAvanzadaWeb_Sema02._1.ViewModel;
using System.Diagnostics;
using System.Text;

namespace APW.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7154/api/Vehicle/all");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var cars = JsonProvider.DeserializeSimple<IEnumerable<CarViewModel>>(jsonString);
                return View(cars);
            }
            else
            {
                return View(new List<CarViewModel>());
            }
        }

        public async Task<IActionResult> Create()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7154/api/Vehicle/all");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var cars = JsonProvider.DeserializeSimple<IEnumerable<CarViewModel>>(jsonString);
                return View(new CreateCarViewModel { NewCar = new CarViewModel(), Cars = cars });
            }
            else
            {
                return View(new CreateCarViewModel { NewCar = new CarViewModel(), Cars = new List<CarViewModel>() });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarViewModel model)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonProvider.Serialize(model.NewCar);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7154/api/Vehicle", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Read(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View();
            }

            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7154/api/Vehicle/{id}");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var car = JsonProvider.DeserializeSimple<CarViewModel>(jsonString);
                return View(car);
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> Update(string id)
        {
            var client = _clientFactory.CreateClient();
            var responseCar = await client.GetAsync($"https://localhost:7154/api/Vehicle/{id}");
            var responseCars = await client.GetAsync("https://localhost:7154/api/Vehicle/all");

            if (responseCar.IsSuccessStatusCode && responseCars.IsSuccessStatusCode)
            {
                var jsonStringCar = await responseCar.Content.ReadAsStringAsync();
                var jsonStringCars = await responseCars.Content.ReadAsStringAsync();
                var car = JsonProvider.DeserializeSimple<CarViewModel>(jsonStringCar);
                var cars = JsonProvider.DeserializeSimple<IEnumerable<CarViewModel>>(jsonStringCars);
                return View(new UpdateCarViewModel { Car = car, Cars = cars });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCarViewModel model)
        {
            var client = _clientFactory.CreateClient();
            var json = JsonProvider.Serialize(model.Car);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"https://localhost:7154/api/Vehicle/{model.Car.Id}", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            var client = _clientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7154/api/Vehicle/all");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var cars = JsonProvider.DeserializeSimple<IEnumerable<CarViewModel>>(jsonString);
                return View(new DeleteCarViewModel { Cars = cars });
            }
            else
            {
                return View(new DeleteCarViewModel { Cars = new List<CarViewModel>() });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var client = _clientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7154/api/Vehicle/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Delete");
            }
            else
            {
                return RedirectToAction("Delete");
            }
        }
    }

    public class CreateCarViewModel
    {
        public CarViewModel NewCar { get; set; }
        public IEnumerable<CarViewModel> Cars { get; set; }
    }

    public class UpdateCarViewModel
    {
        public CarViewModel Car { get; set; }
        public IEnumerable<CarViewModel> Cars { get; set; }
    }

    public class DeleteCarViewModel
    {
        public IEnumerable<CarViewModel> Cars { get; set; }
    }
}
