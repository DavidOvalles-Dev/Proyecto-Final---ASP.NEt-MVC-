using proyecto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Contract
{
    public interface IMiembroService : IBaseService<Miembro>
    {
        // Elimina este método:
        // Task<IEnumerable<Miembro>> GetMiembrosByActividadIdAsync(int actividadId);
    }
}
