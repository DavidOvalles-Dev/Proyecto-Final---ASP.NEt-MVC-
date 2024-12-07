using proyecto.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto.Infrastructure.Contract
{
    public interface IReporteService
    {
        Task<List<ReporteActividadesDto>> ObtenerActividadesPorMiembroAsync();
        Task<List<ReportePagosDto>> ObtenerPagosPorMiembroAsync();
    }



}
