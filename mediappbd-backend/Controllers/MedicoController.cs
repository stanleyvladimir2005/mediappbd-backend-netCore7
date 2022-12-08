using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private DatabaseConnection _connection;

        public MedicoController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetMedicos()
        {
            if (_connection.Medico is null)
                return NotFound();

            return await _connection.Medico.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetMedico(int id)
        {
            if (_connection.Medico is null)
                return NotFound();

            var medico = await _connection.Medico.FindAsync(id);
            if (medico is null)
                return NotFound();

            return medico;
        }

        [HttpPost]
        public async Task<ActionResult<Medico>> PostMedico(Medico med)
        {
            _connection.Medico.Add(med);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(GetMedico), new { id = med.Id }, med);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMedico(int id, Medico med)
        {
            if (id != med.Id)
                return BadRequest();

            _connection.Entry(med).State = EntityState.Modified;
            try
            {
                await _connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicoExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedico(int id)
        {
            if (_connection.Medico is null)
                return NotFound();

            var medico = await _connection.Medico.FindAsync(id);
            if (medico is null)
                return NotFound();

            _connection.Medico.Remove(medico);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool MedicoExists(long id)
        {
            return (_connection.Medico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
    

