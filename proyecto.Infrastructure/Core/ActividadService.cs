using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Services
{
    public class ActividadService : BaseService<Actividad>, IActividadService
    {
        private readonly ApplicationDbContext _context;

        public ActividadService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        // Elimina este método porque ya no se necesita
        // public async Task<IEnumerable<Actividad>> GetActividadesByMiembroIdAsync(int miembroId)
        // {
        //     return await Task.FromResult(new List<Actividad>());
        // }
    }
}
