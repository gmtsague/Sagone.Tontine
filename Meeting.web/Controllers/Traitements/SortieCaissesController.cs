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

namespace Meeting.web.Controllers.Traitements
{
    public class SortieCaissesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<SortieCaissesController> _logger;

        public SortieCaissesController(ILogger<SortieCaissesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: SortieCaisses
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Sortie de caisse");

            TypeAdapterConfig<MeetSortieCaisse,SortieCaisseDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetSortieCaisses
                                       .Include(m => m.Engagement)
                                       .Include(m => m.Seance)
                                       .Include(m => m.IdinscritNavigation)
                                       .ThenInclude(m=>m.Person)
                                       .AsNoTracking().ProjectToType<SortieCaisseDto>();
            return View(await labosContext.ToListAsync());
        }

        // GET: SortieCaisses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses
                .Include(m => m.Engagement)
                .Include(m => m.IdinscritNavigation)
                .Include(m => m.Seance)
                .FirstOrDefaultAsync(m => m.SortiecaisseId == id);
            if (meetSortieCaisse == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", meetSortieCaisse.Adapt<SortieCaisseDto>());
        }

        // GET: SortieCaisses/Create
        public IActionResult Create()
        {
            ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId");
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return PartialView("Create");
        }

        // POST: SortieCaisses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SortiecaisseId,Idinscrit,SeanceId,EngagementId,MontantRoute,ListeMandataires,Dateevts,Montantpercu,Note,IsClosed,Visarestants")] SortieCaisseDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetSortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                _context.Add(meetSortieCaisse);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId", valueDto.EngagementId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.SeanceId);
            return View("Create",valueDto);
        }

        // GET: SortieCaisses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses.FindAsync(id);
            if (meetSortieCaisse == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId", meetSortieCaisse.EngagementId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)meetSortieCaisse.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetSortieCaisse.SeanceId);
            return PartialView("Edit", meetSortieCaisse.Adapt<SortieCaisseDto>());
        }

        // POST: SortieCaisses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SortiecaisseId,Idinscrit,SeanceId,EngagementId,MontantRoute,ListeMandataires,Dateevts,Montantpercu,Note,IsClosed,Visarestants")] SortieCaisseDto valueDto)
        {
            if (id != valueDto.SortiecaisseId)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var meetSortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                    _context.Update(meetSortieCaisse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetSortieCaisseExists(valueDto.SortiecaisseId))
                    {
                        //return NotFound();
                        return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId", valueDto.EngagementId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long) valueDto.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.SeanceId);
            return PartialView("Edit", valueDto);
        }

        // GET: SortieCaisses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                return NotFound();
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses
                .Include(m => m.Engagement)
                .Include(m => m.IdinscritNavigation)
                .Include(m => m.Seance)
                .FirstOrDefaultAsync(m => m.SortiecaisseId == id);
            if (meetSortieCaisse == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", meetSortieCaisse.Adapt<SortieCaisseDto>());
        }

        // POST: SortieCaisses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetSortieCaisses == null)
            {
                return Problem("Entity set 'LabosContext.MeetSortieCaisses'  is null.");
            }
            var meetSortieCaisse = await _context.MeetSortieCaisses.FindAsync(id);
            if (meetSortieCaisse != null)
            {
                _context.MeetSortieCaisses.Remove(meetSortieCaisse);
            }

            int NbSaved = await _context.SaveChangesAsync();
            if (NbSaved > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        private bool MeetSortieCaisseExists(int id)
        {
          return (_context.MeetSortieCaisses?.Any(e => e.SortiecaisseId == id)).GetValueOrDefault();
        }
    }
}
