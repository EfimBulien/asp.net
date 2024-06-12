using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectEMIAS_API.Models;

namespace FinalProjectEMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionsController : ControllerBase
    {
        private readonly FinalProjectEmiasContext _context;

        public DirectionsController(FinalProjectEmiasContext context)
        {
            _context = context;
        }

        // GET: api/Directions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direction>>> GetDirections()
        {
          if (_context.Directions == null)
          {
              return NotFound();
          }
            return await _context.Directions.ToListAsync();
        }

        // GET: api/Directions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Direction>> GetDirection(int? id)
        {
          if (_context.Directions == null)
          {
              return NotFound();
          }
            var direction = await _context.Directions.FindAsync(id);

            if (direction == null)
            {
                return NotFound();
            }

            return direction;
        }

        // PUT: api/Directions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirection(int? id, Direction direction)
        {
            if (id != direction.IdDirection)
            {
                return BadRequest();
            }

            _context.Entry(direction).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectionExists(id))
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

        // POST: api/Directions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Direction>> PostDirection(Direction direction)
        {
          if (_context.Directions == null)
          {
              return Problem("Entity set 'FinalProjectEmiasContext.Directions'  is null.");
          }
            _context.Directions.Add(direction);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDirection", new { id = direction.IdDirection }, direction);
        }

        // DELETE: api/Directions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirection(int? id)
        {
            if (_context.Directions == null)
            {
                return NotFound();
            }
            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }

            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectionExists(int? id)
        {
            return (_context.Directions?.Any(e => e.IdDirection == id)).GetValueOrDefault();
        }
    }
}
