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
    public class AntennesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<AntennesController> _logger;

        public AntennesController(ILogger<AntennesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Antennes
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Region");

            var labosContext = _context.MeetAntennes.Include(m => m.Etab);
            return View(await labosContext.OrderBy(m=>m.Libelle).AsQueryable().ProjectToType<AntenneDto>().ToListAsync());
        }

        // GET: Antennes/Details/5
        public async Task<IActionResult> Details(int? IdEtab, int? IdAntenne)
        {
            if (IdEtab == null || IdAntenne == null || _context.MeetAntennes == null)
            {
                return NotFound();
            }

            var meetAntenne = await _context.MeetAntennes
                .Include(m => m.Etab)
                .FirstOrDefaultAsync(m => m.EtabId == IdEtab && m.AntenneId == IdAntenne);
            if (meetAntenne == null)
            {
                return NotFound();
            }

            return PartialView("Details",meetAntenne.Adapt<AntenneDto>());
        }

        // GET: Antennes/Create
        public IActionResult CreateView()
        {
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context);
            return PartialView("CreateView");
        }

        // POST: Antennes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("EtabId,AntenneId,Libelle,Creationdate")] AntenneDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetAntenne = valueDto.ToEntity();
                _context.Add(meetAntenne);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, valueDto.EtabId);
            return PartialView("CreateView", valueDto);
            //return PartialView(valueDto);
            // return View(valueDto);
            //return FormResult..CreateErrorResultWithObject(valueDto);
        }

        // GET: Antennes/Edit/5
        public async Task<IActionResult> EditView(int? IdEtab, int? IdAntenne)
        {
            if (IdEtab == null || IdAntenne == null || _context.MeetAntennes == null)
            {
                return NotFound();
            }

            var meetAntenne = await _context.MeetAntennes.FirstOrDefaultAsync(m=>m.EtabId == IdEtab && m.AntenneId == IdAntenne);
            if (meetAntenne == null)
            {
                return NotFound();
            }
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, meetAntenne.EtabId);
            return PartialView("EditView", meetAntenne.Adapt<AntenneDto>());
        }

        // POST: Antennes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int EtabId, int AntenneId, [Bind("EtabId,AntenneId,Libelle,Creationdate")] AntenneDto valueDto)
        {
            if (AntenneId != valueDto.AntenneId && EtabId != valueDto.EtabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var meetAntenne = valueDto.ToEntity();
                try
                {
                    _context.Update(meetAntenne);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetAntenneExists(meetAntenne.EtabId, meetAntenne.AntenneId))
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
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_context, valueDto.EtabId);
            return PartialView("EditView", valueDto);
        }

        // GET: Antennes/Delete/5
        public async Task<IActionResult> DeleteView(int? IdEtab, int? IdAntenne)
        {
            if (IdEtab == null || IdAntenne == null || _context.MeetAntennes == null)
            {
                return NotFound();
            }

            var meetAntenne = await _context.MeetAntennes
                .Include(m => m.Etab)
                .FirstOrDefaultAsync(m => m.EtabId == IdEtab && m.AntenneId == IdAntenne);
            if (meetAntenne == null)
            {
                return NotFound();
            }

            return PartialView("DeleteView",meetAntenne.Adapt<AntenneDto>());
        }

        // POST: Antennes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int? EtabId, int? AntenneId)
        {
            if (_context.MeetAntennes == null)
            {
                //return Problem("Entity set 'LabosContext.MeetAntennes'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var meetAntenne = await _context.MeetAntennes.FirstOrDefaultAsync(m => m.EtabId == EtabId && m.AntenneId == AntenneId);
            if (meetAntenne != null)
            {
                _context.MeetAntennes.Remove(meetAntenne);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool MeetAntenneExists(int IdEtab, int IdAntenne)
        {
          return (_context.MeetAntennes?.Any(e => e.EtabId == IdEtab && e.AntenneId == IdAntenne)).GetValueOrDefault();
        }
    }
}
