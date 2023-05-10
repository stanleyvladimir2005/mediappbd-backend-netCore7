using mediappbd_backend.Data;
using mediappbd_backend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace mediappbd_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private DatabaseConnection _connection;

        public ExamController(DatabaseConnection connection)
        {
            _connection = connection;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exam>>> Getexams()
        {
            if (_connection.exam is null)
                return NotFound();

            return await _connection.exam.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exam>> Getexam(int id)
        {
            if (_connection.exam is null)
                return NotFound();

            var exam = await _connection.exam.FindAsync(id);
            if (exam is null)
                return NotFound();

            return exam;
        }

        [HttpPost]
        public async Task<ActionResult<Exam>> Postexam(Exam exa)
        {
            _connection.exam.Add(exa);
            await _connection.SaveChangesAsync();
            return CreatedAtAction(nameof(Getexam), new { id = exa.Id }, exa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Putexam(int id, Exam exa)
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
                if (!examExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteexam(int id)
        {
            if (_connection.exam is null)
                return NotFound();

            var exam = await _connection.exam.FindAsync(id);
            if (exam is null)
                return NotFound();

            _connection.exam.Remove(exam);
            await _connection.SaveChangesAsync();
            return NoContent();
        }

        private bool examExists(long id)
        {
            return (_connection.exam?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

