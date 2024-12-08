using Microsoft.AspNetCore.Mvc;
using proyecto.Infrastructure.Contract;
using proyecto.Domain.Entities;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MiembroController : BaseController<Miembro>
    {
        private readonly IMiembroService _miembroService;

        // El servicio de miembros es inyectado desde la clase base
        public MiembroController(IMiembroService miembroService) : base(miembroService)
        {
            _miembroService = miembroService;
        }

        // Si necesitas lógica adicional que no esté en la clase base,
        // puedes agregarla aquí. Pero no es necesario para los métodos CRUD básicos.
    }
}
