using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinalProjectEMIAS_API.Models;

namespace FinalProjectEMIAS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchDocumentsController : ControllerBase
    {
        private readonly FinalProjectEmiasContext _context;

        public ResearchDocumentsController(FinalProjectEmiasContext context)
        {
            _context = context;
        }

        // GET: api/ResearchDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ResearchDocument>>> GetResearchDocuments()
        {
          if (_context.ResearchDocuments == null)
          {
              return NotFound();
          }
            return await _context.ResearchDocuments.ToListAsync();
        }

        // GET: api/ResearchDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ResearchDocument>> GetResearchDocument(int? id)
        {
          if (_context.ResearchDocuments == null)
          {
              return NotFound();
          }
            var researchDocument = await _context.ResearchDocuments.FindAsync(id);

            if (researchDocument == null)
            {
                return NotFound();
            }

            return researchDocument;
        }

        // PUT: api/ResearchDocuments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResearchDocument(int? id, ResearchDocument researchDocument)
        {
            if (id != researchDocument.IdResearchDocument)
            {
                return BadRequest();
            }

            _context.Entry(researchDocument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResearchDocumentExists(id))
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

        // POST: api/ResearchDocuments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResearchDocument>> PostResearchDocument(ResearchDocument researchDocument)
        {
          if (_context.ResearchDocuments == null)
          {
              return Problem("Entity set 'FinalProjectEmiasContext.ResearchDocuments'  is null.");
          }
            _context.ResearchDocuments.Add(researchDocument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResearchDocument", new { id = researchDocument.IdResearchDocument }, researchDocument);
        }

        // DELETE: api/ResearchDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResearchDocument(int? id)
        {
            if (_context.ResearchDocuments == null)
            {
                return NotFound();
            }
            var researchDocument = await _context.ResearchDocuments.FindAsync(id);
            if (researchDocument == null)
            {
                return NotFound();
            }

            _context.ResearchDocuments.Remove(researchDocument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResearchDocumentExists(int? id)
        {
            return (_context.ResearchDocuments?.Any(e => e.IdResearchDocument == id)).GetValueOrDefault();
        }
    }
}
