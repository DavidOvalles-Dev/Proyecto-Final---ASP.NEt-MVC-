using proyecto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Contract
{
    public interface IEventoService : IBaseService<Evento>
    {
        Task<IEnumerable<Evento>> GetEventosByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Evento>> GetEventosByCostoAsync(decimal minCosto, decimal maxCosto);
    }
}
