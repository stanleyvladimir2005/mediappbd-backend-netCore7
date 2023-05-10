using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private DatabaseConnection _connection;

        public SpecialtyController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Specialty>>> GetSpecialtys()
        {
            if (_connection.specialty is null)
                return NotFound();

            return await _connection.specialty.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Specialty>> GetSpecialty(int id)
        {
            if (_connection.specialty is null)
                return NotFound();

            var Specialty = await _connection.specialty.FindAsync(id);
            if (Specialty is null)
                return NotFound();

            return Specialty;
        }

        [HttpPost]
        public async Task<ActionResult<Specialty>> PostSpecialty(Specialty esp)
        {
            _connection.specialty.Add(esp);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(GetSpecialty), new { id = esp.Id }, esp);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialty(int id, Specialty esp)
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
                if (!SpecialtyExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecialty(int id)
        {
            if (_connection.specialty is null)
                return NotFound();

            var Specialty = await _connection.specialty.FindAsync(id);
            if (Specialty is null)
                return NotFound();

            _connection.specialty.Remove(Specialty);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool SpecialtyExists(long id)
        {
            return (_connection.specialty?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
