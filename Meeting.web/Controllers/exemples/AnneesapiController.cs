using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;

namespace Meeting.web.Controllers.exemples
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnneesapiController : ControllerBase
    {
        private readonly LabosContext _context;

        public AnneesapiController(LabosContext context)
        {
            _context = context;
        }

        // GET: api/Anneesapi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoreAnnee>>> GetCoreAnnees()
        {
            if (_context.CoreAnnees == null)
            {
                return NotFound();
            }
            return await _context.CoreAnnees.ToListAsync();
        }

        // GET: api/Anneesapi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoreAnnee>> GetCoreAnnee(int id)
        {
            if (_context.CoreAnnees == null)
            {
                return NotFound();
            }
            var coreAnnee = await _context.CoreAnnees.FindAsync(id);

            if (coreAnnee == null)
            {
                return NotFound();
            }

            return coreAnnee;
        }

        // PUT: api/Anneesapi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoreAnnee(int id, CoreAnnee coreAnnee)
        {
            if (id != coreAnnee.AnneeId)
            {
                return BadRequest();
            }

            _context.Entry(coreAnnee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreAnneeExists(id))
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

        // POST: api/Anneesapi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoreAnnee>> PostCoreAnnee(CoreAnnee coreAnnee)
        {
            if (_context.CoreAnnees == null)
            {
                return Problem("Entity set 'LabosContext.CoreAnnees'  is null.");
            }
            _context.CoreAnnees.Add(coreAnnee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoreAnnee", new { id = coreAnnee.AnneeId }, coreAnnee);
        }

        // DELETE: api/Anneesapi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoreAnnee(int id)
        {
            if (_context.CoreAnnees == null)
            {
                return NotFound();
            }
            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee == null)
            {
                return NotFound();
            }

            _context.CoreAnnees.Remove(coreAnnee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoreAnneeExists(int id)
        {
            return (_context.CoreAnnees?.Any(e => e.AnneeId == id)).GetValueOrDefault();
        }
    }
}
