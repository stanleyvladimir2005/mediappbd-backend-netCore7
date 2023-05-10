using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private DatabaseConnection _connection;

        public MedicController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medic>>> Getmedics()
        {
            if (_connection.medic is null)
                return NotFound();

            return await _connection.medic.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Medic>> Getmedic(int id)
        {
            if (_connection.medic is null)
                return NotFound();

            var medic = await _connection.medic.FindAsync(id);
            if (medic is null)
                return NotFound();

            return medic;
        }

        [HttpPost]
        public async Task<ActionResult<Medic>> Postmedic(Medic med)
        {
            _connection.medic.Add(med);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(Getmedic), new { id = med.Id }, med);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putmedic(int id, Medic med)
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
                if (!medicExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletemedic(int id)
        {
            if (_connection.medic is null)
                return NotFound();

            var medic = await _connection.medic.FindAsync(id);
            if (medic is null)
                return NotFound();

            _connection.medic.Remove(medic);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool medicExists(long id)
        {
            return (_connection.medic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
    

