using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenController : ControllerBase
    {
        private DatabaseConnection _connection;

        public ExamenController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Examen>>> GetExamens()
        {
            if (_connection.Examen is null)
                return NotFound();

            return await _connection.Examen.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Examen>> GetExamen(int id)
        {
            if (_connection.Examen is null)
                return NotFound();

            var examen = await _connection.Examen.FindAsync(id);
            if (examen is null)
                return NotFound();

            return examen;
        }

        [HttpPost]
        public async Task<ActionResult<Examen>> PostExamen(Examen exa)
        {
            _connection.Examen.Add(exa);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(GetExamen), new { id = exa.Id }, exa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExamen(int id, Examen exa)
        {
            if (id != exa.Id)
                return BadRequest();

            _connection.Entry(exa).State = EntityState.Modified;
            try
            {
                await _connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExamenExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExamen(int id)
        {
            if (_connection.Examen is null)
                return NotFound();

            var Examen = await _connection.Examen.FindAsync(id);
            if (Examen is null)
                return NotFound();

            _connection.Examen.Remove(Examen);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool ExamenExists(long id)
        {
            return (_connection.Examen?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

