using Microsoft.AspNetCore.Mvc;
using proyecto.Domain.Entities;
using proyecto.Infrastructure.Contract;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : BaseController<Pago>
    {
        public PagoController(IBaseService<Pago> pagoService) : base(pagoService)
        {
        }
    }
}
