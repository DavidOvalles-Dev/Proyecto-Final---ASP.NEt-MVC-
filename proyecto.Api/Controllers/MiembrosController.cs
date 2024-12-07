using Microsoft.AspNetCore.Mvc;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroController : BaseController<Miembro>
    {
        private readonly IMiembroService _miembroService;

        public MiembroController(IMiembroService miembroService) : base(miembroService)
        {
            _miembroService = miembroService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var miembros = await _miembroService.GetAllAsync();
            if (miembros == null || !miembros.Any())
            {
                return NotFound("No hay miembros disponibles.");
            }

            return Ok(miembros.Select(m => new
            {
                m.Id,
                m.Nombre,
                m.Apellido
            }));
        }


        // Método personalizado: Obtener miembros por ActividadId
        [HttpGet("ByActividad/{actividadId}")]
        public async Task<IActionResult> GetMiembrosByActividadId(int actividadId)
        {
            var miembros = await _miembroService.GetMiembrosByActividadIdAsync(actividadId);
            return Ok(miembros);
        }
    }
}
