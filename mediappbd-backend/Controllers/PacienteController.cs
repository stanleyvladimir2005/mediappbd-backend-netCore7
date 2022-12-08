using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private DatabaseConnection _connection;

        public PacienteController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            if (_connection.Paciente is null)         
                return NotFound();
            
            return await _connection.Paciente.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            if (_connection.Paciente is null)            
                return NotFound();
            
            var paciente = await _connection.Paciente.FindAsync(id);
            if (paciente is null)        
                return NotFound();
            
            return paciente;
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente pac)
        {
            _connection.Paciente.Add(pac);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPaciente), new { id = pac.Id }, pac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente pac)
        {
            if (id != pac.Id)           
                return BadRequest();

            _connection.Entry(pac).State = EntityState.Modified;
            try
            {
                await _connection.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))              
                    return NotFound();              
                else               
                   throw;              
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            if (_connection.Paciente is null)           
                return NotFound();
            
            var paciente = await _connection.Paciente.FindAsync(id);
            if (paciente is null)           
                return NotFound();
            
            _connection.Paciente.Remove(paciente);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool PacienteExists(long id)
        {
            return (_connection.Paciente?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}