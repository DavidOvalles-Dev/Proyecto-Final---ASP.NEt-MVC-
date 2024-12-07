
using proyecto.Application.DTOs;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class ReporteService : IReporteService
{
    private readonly IBaseService<Miembro> _miembroRepository;
    private readonly IBaseService<Pago> _pagoRepository;

    public ReporteService(IBaseService<Miembro> miembroRepository, IBaseService<Pago> pagoRepository)
    {
        _miembroRepository = miembroRepository;
        _pagoRepository = pagoRepository;
    }

    public async Task<List<ReporteActividadesDto>> ObtenerActividadesPorMiembroAsync()
    {
        // Implementación del método para actividades
        return new List<ReporteActividadesDto>();
    }

    public async Task<List<ReportePagosDto>> ObtenerPagosPorMiembroAsync()
    {
        var miembros = await _miembroRepository.GetAllAsync();
        var pagos = await _pagoRepository.GetAllAsync();

        var reportes = miembros.Select(miembro => new ReportePagosDto
        {
            MiembroId = miembro.Id,
            NombreCompleto = $"{miembro.Nombre} {miembro.Apellido}",
            TotalPagado = pagos.Where(p => p.MiembroId == miembro.Id).Sum(p => p.Monto)
        }).ToList();

        return reportes;
    }
}
