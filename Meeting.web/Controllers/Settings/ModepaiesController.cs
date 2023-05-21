using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Mapster;
using Meeting.Web.Dto;
using FormHelper;

namespace Meeting.web.Controllers.Settings
{
    public class ModepaiesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<ModepaiesController> _logger;

        public ModepaiesController(ILogger<ModepaiesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Modepaies
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Mode paiement");

            return _context.CoreModepaies != null ? 
                          View(await _context.CoreModepaies.AsQueryable().ProjectToType<ModepaieDto>().ToListAsync()) :
                          Problem("Entity set 'LabosContext.CoreModepaies'  is null.");
        }

        // GET: Modepaies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreModepaies == null)
            {
                return NotFound();
            }

            var coreModepaie = await _context.CoreModepaies
                .FirstOrDefaultAsync(m => m.ModepaieId == id);
            if (coreModepaie == null)
            {
                return NotFound();
            }

            return PartialView("Details", coreModepaie.Adapt<ModepaieDto>());
        }

        // GET: Modepaies/Create
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Modepaies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("ModepaieId,Libelle,IsCash")] ModepaieDto valueDto)
        {
            if (ModelState.IsValid)
            {
                CoreModepaie coreModepaie = valueDto.ToEntity();
                _context.Add(coreModepaie);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            return PartialView("Create", valueDto);
        }

        // GET: Modepaies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreModepaies == null)
            {
                return NotFound();
            }

            var coreModepaie = await _context.CoreModepaies.FindAsync(id);
            if (coreModepaie == null)
            {
                return NotFound();
            }
            return PartialView("Edit", coreModepaie.Adapt<ModepaieDto>());
        }

        // POST: Modepaies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("ModepaieId,Libelle,IsCash")] ModepaieDto valueDto)
        {
            if (id != valueDto.ModepaieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                CoreModepaie coreModepaie = valueDto.ToEntity();
                try
                {
                    _context.Update(coreModepaie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreModepaieExists(coreModepaie.ModepaieId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            return PartialView("Edit", valueDto);
        }

        // GET: Modepaies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreModepaies == null)
            {
                return NotFound();
            }

            var coreModepaie = await _context.CoreModepaies
                .FirstOrDefaultAsync(m => m.ModepaieId == id);
            if (coreModepaie == null)
            {
                return NotFound();
            }

            return PartialView(coreModepaie.Adapt<ModepaieDto>());
        }

        // POST: Modepaies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreModepaies == null)
            {
                // return Problem("Entity set 'LabosContext.CoreModepaies'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var coreModepaie = await _context.CoreModepaies.FindAsync(id);
            if (coreModepaie != null)
            {
                _context.CoreModepaies.Remove(coreModepaie);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool CoreModepaieExists(int id)
        {
          return (_context.CoreModepaies?.Any(e => e.ModepaieId == id)).GetValueOrDefault();
        }
    }
}
