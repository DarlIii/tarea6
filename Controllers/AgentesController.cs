using Microsoft.AspNetCore.Mvc;
using ApiMigracion.Data;
using ApiMigracion.Models;

namespace ApiMigracion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AgentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Agente agente)
        {
            if (_context.Agentes.Any(a => a.Cedula == agente.Cedula || a.Correo == agente.Correo))
                return BadRequest("Agente ya registrado.");

            _context.Agentes.Add(agente);
            await _context.SaveChangesAsync();
            return Ok(agente);
        }

        [HttpPost("login")]
        public IActionResult Login(string cedulaOrEmail, string clave)
        {
            var agente = _context.Agentes.FirstOrDefault(a => 
                (a.Cedula == cedulaOrEmail || a.Correo == cedulaOrEmail) && a.Clave == clave);

            return agente != null ? Ok(agente) : Unauthorized("Credenciales incorrectas.");
        }
    }
}
