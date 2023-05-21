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
    public class ConfigvisasController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<ConfigvisasController> _logger;

        public ConfigvisasController(ILogger<ConfigvisasController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Configvisas
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Config. signatures documents");

            TypeAdapterConfig<MeetConfigVisa, ConfigvisaDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetConfigVisas.Include(m => m.Annee).Include(m => m.Poste).Include(m => m.Typerub);
            return View(await labosContext.AsQueryable().ProjectToType<ConfigvisaDto>().ToListAsync());
        }

        // GET: Configvisas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetConfigVisas == null)
            {
                return NotFound();
            }

            var meetConfigVisa = await _context.MeetConfigVisas
                .Include(m => m.Annee)
                .Include(m => m.Poste)
                .Include(m => m.Typerub)
                .FirstOrDefaultAsync(m => m.ConfigvisaId == id);
            if (meetConfigVisa == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetConfigVisa.Adapt<ConfigvisaDto>());
        }

        // GET: Configvisas/Create
        public IActionResult Create()
        {
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context);
            ViewData["PosteId"] = UtilityController.GetSelectListOfPostes(_context);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context);
            return PartialView("Create");
        }

        // POST: Configvisas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("ConfigvisaId,PosteId,AnneeId,TyperubId,Numordre,SignByOrdre")] ConfigvisaDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetConfigVisa = valueDto.ToEntity();
                _context.Add(meetConfigVisa);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["PosteId"] = UtilityController.GetSelectListOfPostes(_context, valueDto.PosteId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, valueDto.TyperubId);
            return PartialView("Create",valueDto);
        }

        // GET: Configvisas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetConfigVisas == null)
            {
                return NotFound();
            }

            var meetConfigVisa = await _context.MeetConfigVisas.FindAsync(id);
            if (meetConfigVisa == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetConfigVisa.AnneeId);
            ViewData["PosteId"] = UtilityController.GetSelectListOfPostes(_context, meetConfigVisa.PosteId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, meetConfigVisa.TyperubId);
            return PartialView("Edit", meetConfigVisa.Adapt<ConfigvisaDto>());
        }

        // POST: Configvisas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("ConfigvisaId,PosteId,AnneeId,TyperubId,Numordre,SignByOrdre")] ConfigvisaDto valueDto)
        {
            if (id != valueDto.ConfigvisaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 var meetConfigVisa = valueDto.ToEntity();                
                try
                {
                    _context.Update(meetConfigVisa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetConfigVisaExists(meetConfigVisa.ConfigvisaId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["PosteId"] = UtilityController.GetSelectListOfPostes(_context, valueDto.PosteId);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_context, valueDto.TyperubId);
            return PartialView("Edit", valueDto);
        }

        // GET: Configvisas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetConfigVisas == null)
            {
                return NotFound();
            }

            var meetConfigVisa = await _context.MeetConfigVisas
                .Include(m => m.Annee)
                .Include(m => m.Poste)
                .Include(m => m.Typerub)
                .FirstOrDefaultAsync(m => m.ConfigvisaId == id);
            if (meetConfigVisa == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetConfigVisa.Adapt<ConfigvisaDto>());
        }

        // POST: Configvisas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetConfigVisas == null)
            {
                // return Problem("Entity set 'LabosContext.MeetConfigVisas'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var meetConfigVisa = await _context.MeetConfigVisas.FindAsync(id);
            if (meetConfigVisa != null)
            {
                _context.MeetConfigVisas.Remove(meetConfigVisa);
            }
            
            await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool MeetConfigVisaExists(int id)
        {
          return (_context.MeetConfigVisas?.Any(e => e.ConfigvisaId == id)).GetValueOrDefault();
        }
    }
}
