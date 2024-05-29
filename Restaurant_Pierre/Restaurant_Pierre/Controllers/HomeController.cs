using IDGS902.CATestApi.ApiClima;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Pierre.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Restaurant_Pierre.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Busqueda(string ciudad)
        {
            //http://api.weatherapi.com/v1/current.json?q=iguala


            Console.WriteLine("Ciudad:");
            //string ciudad = Console.ReadLine();
            string key = "b909aa9f776f40f290b172726242005";
            string url = $"http://api.weatherapi.com/v1/current.json?q={ciudad}&key={key}";

            HttpClient client = new HttpClient();

            HttpResponseMessage result = await client.GetAsync(url);


            string data = await result.Content.ReadAsStringAsync();
            //Deserializar
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            RespuestaClima respuesta = JsonSerializer.Deserialize<RespuestaClima>(data, options);

            Console.WriteLine(respuesta.Location.Name);

            Console.WriteLine(respuesta.Location.Region);
            Console.WriteLine(respuesta.Location.Country);
            Console.WriteLine(respuesta.Location.Lat);
            Console.WriteLine(respuesta.Location.Lon);
            Console.WriteLine(respuesta.Current.Temp_f + "°f");
            Console.WriteLine(respuesta.Current.Temp_c + "°c");
            Console.WriteLine(respuesta.Current.Last_updated);

            //foreach (var item in respuesta)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Craft);
            //}
            //Console.WriteLine(data);
            ViewBag.City = respuesta.Location.Name +"/"+respuesta.Location.Region+"/"+respuesta.Location.Country;
            ViewBag.Clima= respuesta.Current.Temp_c+"°c/"+respuesta.Current.Temp_f+"°f"+respuesta.Current.Last_updated;


            //Console.ReadKey();



            return View(Busqueda(ciudad));
        }
        //public IActionResult Index(RespuestaClima respuestaClima)
        //{

        //    return View();
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
