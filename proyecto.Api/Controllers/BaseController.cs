
using Microsoft.AspNetCore.Mvc;
using proyecto.Infrastructure;
using System.Threading.Tasks;
using System.Collections.Generic;
using proyecto.Infrastructure.Contract;

namespace proyecto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : class
    {
        private readonly IBaseService<T> _baseService;

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var entities = await _baseService.GetAllAsync();
            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            if (entity == null)
                return NotFound();

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdEntity = await _baseService.CreateAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity }, createdEntity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] T entity)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            await _baseService.UpdateAsync(entity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _baseService.DeleteAsync(id);
            return NoContent();
        }
    }
}
