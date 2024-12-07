using proyecto.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Contract
{
    public interface IPagoService : IBaseService<Pago>
    {
        Task<List<Pago>> GetPaymentsByMemberIdAsync(int memberId);
        Task<decimal> GetTotalPaymentsAsync();
    }
}
