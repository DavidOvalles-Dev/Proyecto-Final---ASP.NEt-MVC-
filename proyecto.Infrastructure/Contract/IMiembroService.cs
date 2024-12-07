using proyecto.Domain.Entities;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Contract
{
    public interface IMiembroService : IBaseService<Miembro>
    {
        Task<IEnumerable<Miembro>> GetMiembrosByActividadIdAsync(int actividadId);
    }
}
