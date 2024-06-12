using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectEMIAS_API.Models;

namespace FinalProjectEMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialitiesController : ControllerBase
    {
        private readonly FinalProjectEmiasContext _context;

        public SpecialitiesController(FinalProjectEmiasContext context)
        {
            _context = context;
        }

        // GET: api/Specialities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Speciality>>> GetSpecialities()
        {
          if (_context.Specialities == null)
          {
              return NotFound();
          }
            return await _context.Specialities.ToListAsync();
        }

        // GET: api/Specialities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Speciality>> GetSpeciality(int? id)
        {
          if (_context.Specialities == null)
          {
              return NotFound();
          }
            var speciality = await _context.Specialities.FindAsync(id);

            if (speciality == null)
            {
                return NotFound();
            }

            return speciality;
        }

        // PUT: api/Specialities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpeciality(int? id, Speciality speciality)
        {
            if (id != speciality.IdSpeciality)
            {
                return BadRequest();
            }

            _context.Entry(speciality).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Specialities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Speciality>> PostSpeciality(Speciality speciality)
        {
          if (_context.Specialities == null)
          {
              return Problem("Entity set 'FinalProjectEmiasContext.Specialities'  is null.");
          }
            _context.Specialities.Add(speciality);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpeciality", new { id = speciality.IdSpeciality }, speciality);
        }

        // DELETE: api/Specialities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpeciality(int? id)
        {
            if (_context.Specialities == null)
            {
                return NotFound();
            }
            var speciality = await _context.Specialities.FindAsync(id);
            if (speciality == null)
            {
                return NotFound();
            }

            _context.Specialities.Remove(speciality);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpecialityExists(int? id)
        {
            return (_context.Specialities?.Any(e => e.IdSpeciality == id)).GetValueOrDefault();
        }
    }
}
