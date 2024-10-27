using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace ApiMigracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClimaController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "f0c9068d96ec4119987230951240508";

        public ClimaController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetClima(double lat, double lon)
        {
            try
            {
                var url = $"http://api.weatherapi.com/v1/forecast.json?key={ApiKey}&q={lat},{lon}&days=3";
                var weather = await _httpClient.GetFromJsonAsync<dynamic>(url);
                return Ok(weather);
            }
            catch (HttpRequestException)
            {
                return StatusCode(500, "Error al obtener los datos del clima. Verifique la clave de API o intente más tarde.");
            }
        }
    }
}
