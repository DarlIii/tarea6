using Microsoft.AspNetCore.Mvc;
using ApiMigracion.Data;
using ApiMigracion.Models;

namespace ApiMigracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidenciasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public IncidenciasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterIncidencia(Incidencia incidencia)
        {
            _context.Incidencias.Add(incidencia);
            await _context.SaveChangesAsync();
            return Ok(new { ConfirmacionID = incidencia.Id });
        }
    }
}
