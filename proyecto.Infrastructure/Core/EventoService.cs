using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Services
{
    public class EventoService : BaseService<Evento>, IEventoService
    {
        public EventoService(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Evento>> GetEventosByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Eventos
                .Where(e => e.Fecha >= startDate && e.Fecha <= endDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Evento>> GetEventosByCostoAsync(decimal minCosto, decimal maxCosto)
        {
            return await _context.Eventos
                .Where(e => e.Costo >= minCosto && e.Costo <= maxCosto)
                .ToListAsync();
        }
    }
}
