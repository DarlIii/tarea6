using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace ApiMigracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public NoticiasController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<IActionResult> GetNoticias()
        {
            var noticias = await _httpClient.GetFromJsonAsync<dynamic>(
                "https://remolacha.net/wp-json/wp/v2/posts?search=migraci%C3%B3n&_fields=title,excerpt");
            return Ok(noticias);
        }
    }
}
