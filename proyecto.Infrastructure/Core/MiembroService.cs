using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Services
{
    public class MiembroService : BaseService<Miembro>, IMiembroService
    {
        public MiembroService(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Miembro>> GetMiembrosByActividadIdAsync(int actividadId)
        {
            return await _context.MiembroActividades
                .Where(ma => ma.ActividadId == actividadId)
                .Select(ma => ma.Miembro)
                .ToListAsync();
        }
    }
}
