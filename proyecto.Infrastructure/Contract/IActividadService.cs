using System.Collections.Generic;
using System.Threading.Tasks;
using proyecto.Domain.Entities;

namespace proyecto.Infrastructure.Contract
{
    public interface IActividadService : IBaseService<Actividad>
    {
        // Elimina este método:
        // Task<IEnumerable<Actividad>> GetActividadesByMiembroIdAsync(int miembroId);
    }
}
