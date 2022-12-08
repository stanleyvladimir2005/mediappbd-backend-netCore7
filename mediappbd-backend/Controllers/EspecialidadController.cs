using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadController : ControllerBase
    {
        private DatabaseConnection _connection;

        public EspecialidadController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Especialidad>>> GetEspecialidads()
        {
            if (_connection.Especialidad is null)
                return NotFound();

            return await _connection.Especialidad.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Especialidad>> GetEspecialidad(int id)
        {
            if (_connection.Especialidad is null)
                return NotFound();

            var especialidad = await _connection.Especialidad.FindAsync(id);
            if (especialidad is null)
                return NotFound();

            return especialidad;
        }

        [HttpPost]
        public async Task<ActionResult<Especialidad>> PostEspecialidad(Especialidad esp)
        {
            _connection.Especialidad.Add(esp);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEspecialidad), new { id = esp.Id }, esp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspecialidad(int id, Especialidad esp)
        {
            if (id != esp.Id)
                return BadRequest();

            _connection.Entry(esp).State = EntityState.Modified;
            try
            {
                await _connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EspecialidadExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEspecialidad(int id)
        {
            if (_connection.Especialidad is null)
                return NotFound();

            var especialidad = await _connection.Especialidad.FindAsync(id);
            if (especialidad is null)
                return NotFound();

            _connection.Especialidad.Remove(especialidad);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool EspecialidadExists(long id)
        {
            return (_connection.Especialidad?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
