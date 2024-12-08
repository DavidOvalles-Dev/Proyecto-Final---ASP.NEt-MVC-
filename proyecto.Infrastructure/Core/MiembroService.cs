using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Services
{
    public class MiembroService : BaseService<Miembro>, IMiembroService
    {
        public MiembroService(ApplicationDbContext context) : base(context) { }

        // Elimina el método que ya no es necesario
        // public Task<IEnumerable<Miembro>> GetMiembrosByActividadIdAsync(int actividadId)
        // {
        //     throw new NotImplementedException();
        // }

        // Implementa otros métodos específicos para la gestión de Miembros si es necesario.
    }
}
