using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting.Web.Dto;
using MeetingEntities.Models;

namespace Meeting.Web.Controllers.Traitements
{
    public class InscriptionsDtoController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<UtilityController> _logger;

        public InscriptionsDtoController( ILogger<InscriptionsDtoController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.InscriptionDto.Include(i => i.Annee).Include(i => i.Person);
            return View(await labosContext.ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InscriptionDto == null)
            {
                return NotFound();
            }

            var inscriptionDto = await _context.InscriptionDto
                .Include(i => i.Annee)
                .Include(i => i.Person)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (inscriptionDto == null)
            {
                return NotFound();
            }

            return View(inscriptionDto);
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            ViewData["AnneeId"] = new SelectList(_context.Set<AnneeDto>(), "AnneeId", "AnneeId");
            ViewData["PersonId"] = new SelectList(_context.Set<PersonDto>(), "PersonId", "PersonId");
            return View();
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")] InscriptionDto inscriptionDto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscriptionDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeId"] = new SelectList(_context.Set<AnneeDto>(), "AnneeId", "AnneeId", inscriptionDto.AnneeId);
            ViewData["PersonId"] = new SelectList(_context.Set<PersonDto>(), "PersonId", "PersonId", inscriptionDto.PersonId);
            return View(inscriptionDto);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InscriptionDto == null)
            {
                return NotFound();
            }

            var inscriptionDto = await _context.InscriptionDto.FindAsync(id);
            if (inscriptionDto == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = new SelectList(_context.Set<AnneeDto>(), "AnneeId", "AnneeId", inscriptionDto.AnneeId);
            ViewData["PersonId"] = new SelectList(_context.Set<PersonDto>(), "PersonId", "PersonId", inscriptionDto.PersonId);
            return View(inscriptionDto);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")] InscriptionDto inscriptionDto)
        {
            if (id != inscriptionDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscriptionDto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscriptionDtoExists(inscriptionDto.Idinscrit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeId"] = new SelectList(_context.Set<AnneeDto>(), "AnneeId", "AnneeId", inscriptionDto.AnneeId);
            ViewData["PersonId"] = new SelectList(_context.Set<PersonDto>(), "PersonId", "PersonId", inscriptionDto.PersonId);
            return View(inscriptionDto);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InscriptionDto == null)
            {
                return NotFound();
            }

            var inscriptionDto = await _context.InscriptionDto
                .Include(i => i.Annee)
                .Include(i => i.Person)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (inscriptionDto == null)
            {
                return NotFound();
            }

            return View(inscriptionDto);
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InscriptionDto == null)
            {
                return Problem("Entity set 'LabosContext.InscriptionDto'  is null.");
            }
            var inscriptionDto = await _context.InscriptionDto.FindAsync(id);
            if (inscriptionDto != null)
            {
                _context.InscriptionDto.Remove(inscriptionDto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscriptionDtoExists(int id)
        {
          return (_context.InscriptionDto?.Any(e => e.Idinscrit == id)).GetValueOrDefault();
        }
    }
}
