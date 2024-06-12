using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectEMIAS_API.Models;

namespace FinalProjectEMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysDocumentsController : ControllerBase
    {
        private readonly FinalProjectEmiasContext _context;

        public AnalysDocumentsController(FinalProjectEmiasContext context)
        {
            _context = context;
        }

        // GET: api/AnalysDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnalysDocument>>> GetAnalysDocuments()
        {
          if (_context.AnalysDocuments == null)
          {
              return NotFound();
          }
            return await _context.AnalysDocuments.ToListAsync();
        }

        // GET: api/AnalysDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnalysDocument>> GetAnalysDocument(int? id)
        {
          if (_context.AnalysDocuments == null)
          {
              return NotFound();
          }
            var analysDocument = await _context.AnalysDocuments.FindAsync(id);

            if (analysDocument == null)
            {
                return NotFound();
            }

            return analysDocument;
        }

        // PUT: api/AnalysDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnalysDocument(int? id, AnalysDocument analysDocument)
        {
            if (id != analysDocument.IdAnalysDocument)
            {
                return BadRequest();
            }

            _context.Entry(analysDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnalysDocumentExists(id))
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

        // POST: api/AnalysDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnalysDocument>> PostAnalysDocument(AnalysDocument analysDocument)
        {
          if (_context.AnalysDocuments == null)
          {
              return Problem("Entity set 'FinalProjectEmiasContext.AnalysDocuments'  is null.");
          }
            _context.AnalysDocuments.Add(analysDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnalysDocument", new { id = analysDocument.IdAnalysDocument }, analysDocument);
        }

        // DELETE: api/AnalysDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnalysDocument(int? id)
        {
            if (_context.AnalysDocuments == null)
            {
                return NotFound();
            }
            var analysDocument = await _context.AnalysDocuments.FindAsync(id);
            if (analysDocument == null)
            {
                return NotFound();
            }

            _context.AnalysDocuments.Remove(analysDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnalysDocumentExists(int? id)
        {
            return (_context.AnalysDocuments?.Any(e => e.IdAnalysDocument == id)).GetValueOrDefault();
        }
    }
}
