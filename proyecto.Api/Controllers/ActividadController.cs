using Microsoft.AspNetCore.Mvc;
using proyecto.Infrastructure.Contract;
using proyecto.Domain.Entities;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActividadController : BaseController<Actividad>
    {
        private readonly IActividadService _actividadService;

        public ActividadController(IActividadService actividadService) : base(actividadService)
        {
            _actividadService = actividadService;
        }

        // Método personalizado: Obtener actividades por MiembroId
        [HttpGet("ByMiembro/{miembroId}")]
        public async Task<IActionResult> GetActividadesByMiembroId(int miembroId)
        {
            var actividades = await _actividadService.GetActividadesByMiembroIdAsync(miembroId);
            return Ok(actividades);
        }


    }
}
