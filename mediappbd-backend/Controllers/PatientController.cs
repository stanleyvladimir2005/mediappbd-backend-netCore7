using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private DatabaseConnection _connection;

        public PatientController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Getpatients()
        {
            if (_connection.patient is null)         
                return NotFound();
            
            return await _connection.patient.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Getpatient(int id)
        {
            if (_connection.patient is null)            
                return NotFound();
            
            var patient = await _connection.patient.FindAsync(id);
            if (patient is null)        
                return NotFound();
            
            return patient;
        }

        [HttpPost]
        public async Task<ActionResult<Patient>> Postpatient(Patient pac)
        {
            _connection.patient.Add(pac);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(Getpatient), new { id = pac.Id }, pac);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putpatient(int id, Patient pac)
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
                if (!patientExists(id))              
                    return NotFound();              
                else               
                   throw;              
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepatient(int id)
        {
            if (_connection.patient is null)           
                return NotFound();
            
            var patient = await _connection.patient.FindAsync(id);
            if (patient is null)           
                return NotFound();
            
            _connection.patient.Remove(patient);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool patientExists(long id)
        {
            return (_connection.patient?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}