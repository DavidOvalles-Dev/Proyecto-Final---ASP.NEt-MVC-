using Microsoft.AspNetCore.Mvc;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : BaseController<Evento>
    {
        private readonly IEventoService _eventoService;

        public EventoController(IEventoService eventoService) : base(eventoService)
        {
            _eventoService = eventoService;
        }

        // Método personalizado: Obtener eventos por rango de fechas
        [HttpGet("ByDateRange")]
        public async Task<IActionResult> GetEventosByDateRange(DateTime startDate, DateTime endDate)
        {
            var eventos = await _eventoService.GetEventosByDateRangeAsync(startDate, endDate);
            return Ok(eventos);
        }

        // Método personalizado: Obtener eventos por rango de costo
        [HttpGet("ByCostoRange")]
        public async Task<IActionResult> GetEventosByCosto(decimal minCosto, decimal maxCosto)
        {
            var eventos = await _eventoService.GetEventosByCostoAsync(minCosto, maxCosto);
            return Ok(eventos);
        }
    }
}
