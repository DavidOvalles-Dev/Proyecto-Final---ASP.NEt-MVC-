using Microsoft.EntityFrameworkCore;
using proyecto.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proyecto.Infrastructure.Services;
using proyecto.Infrastructure;
using proyecto.Infrastructure.Contract;

namespace proyecto.Application.Core
{
    public class PagoService : BaseService<Pago>, IPagoService
    {
        public PagoService(ApplicationDbContext context) : base(context) { }

        public async Task<List<Pago>> GetPaymentsByMemberIdAsync(int memberId)
        {
            return await _context.Pagos
                .Where(p => p.MiembroId == memberId)
                .ToListAsync();
        }

        public async Task<decimal> GetTotalPaymentsAsync()
        {
            return await _context.Pagos.SumAsync(p => p.Monto);
        }
    }
}
