using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.Web.Dto;
using Mapster;
using FormHelper;

namespace Meeting.web.Controllers.Traitements
{
    public class OrdrePassagesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<OrdrePassagesController> _logger;

        public OrdrePassagesController(ILogger<OrdrePassagesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: OrdrePassages
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Ordre de passages");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            var labosContext = _context.MeetOrdrePassages
                                        .Include(m => m.CoreSubdivision)
                                        .Include(m => m.IdinscritNavigation.MeetAntenne)
                                        //.ThenInclude(m=>m.Person)
                                        .Include(p => p.IdinscritNavigation.Person)
                                        .Where(m => m.IdinscritNavigation.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
                                        .Where(m => m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return View(await labosContext.OrderBy(m=>m.CoreSubdivision.MonthDate).ProjectToType<OrdrePassageDto>().ToListAsync());
        }

        // GET: OrdrePassages
        public async Task<IActionResult> PassagesByAntenne(int Id)
        {          
            ViewData["TitleObj"] = new FormTitle("Ordre de passages");

            //iewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            var labosContext = _context.MeetOrdrePassages.Include(m => m.CoreSubdivision)
                                                         .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                         //.ThenInclude(m=>m.MeetAntenne)
                                                         .Include(p => p.IdinscritNavigation.Person)
                                                         .Where(m => m.IdinscritNavigation.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
                                                         .Where(m => (Id <= 0 || m.IdinscritNavigation.AntenneId == Id) && m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return PartialView("_PartialGridViewPassages", await labosContext.OrderBy(m => m.CoreSubdivision.MonthDate).AsNoTracking().ProjectToType<OrdrePassageDto>().ToListAsync());
        }

        // GET: OrdrePassages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetOrdrePassages == null)
            {
                return NotFound();
            }

            var meetOrdrePassage = await _context.MeetOrdrePassages
                .Include(m => m.CoreSubdivision)
                .Include(m => m.IdinscritNavigation).ThenInclude(m=>m.Person)
                .FirstOrDefaultAsync(m => m.PassageId == id);
            if (meetOrdrePassage == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetOrdrePassage.Adapt<OrdrePassageDto>());
        }

        // GET: OrdrePassages/Create
        public IActionResult Create()
        {
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear());
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            var valueDto = new OrdrePassageDto() 
            { 
                AnneeId = (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0) 
            };
            return PartialView("Create", valueDto);
        }

        // POST: OrdrePassages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("PassageId,AnneeId,DivisionId,Idinscrit,Montantpercu,Heuredebut,Commentaire")] OrdrePassageDto valueDto)
        {
            if (ModelState.IsValid)
            {
                MeetOrdrePassage meetOrdrePassage = valueDto.ToEntity();
                _context.Add(meetOrdrePassage);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear());
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            return PartialView("Create", valueDto);
        }

        // GET: OrdrePassages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetOrdrePassages == null)
            {
                return NotFound();
            }

            var meetOrdrePassage = await _context.MeetOrdrePassages.FindAsync(id);
            if (meetOrdrePassage == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetOrdrePassage.AnneeId);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear(), meetOrdrePassage.DivisionId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)meetOrdrePassage.Idinscrit);
            return PartialView("Edit", meetOrdrePassage.Adapt<OrdrePassageDto>());
        }

        // POST: OrdrePassages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("PassageId,AnneeId,DivisionId,Idinscrit,Montantpercu,Heuredebut,Commentaire")] OrdrePassageDto valueDto)
        {
            if (id != valueDto.PassageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MeetOrdrePassage meetOrdrePassage = valueDto.ToEntity();               
                try
                {
                    _context.Update(meetOrdrePassage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetOrdrePassageExists(meetOrdrePassage.PassageId))
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
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear(), valueDto.DivisionId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            return PartialView("Edit", valueDto);
        }

        // GET: OrdrePassages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetOrdrePassages == null)
            {
                return NotFound();
            }

            var meetOrdrePassage = await _context.MeetOrdrePassages
                .Include(m => m.CoreSubdivision)
                .Include(m => m.IdinscritNavigation).ThenInclude(m => m.Person)
                .FirstOrDefaultAsync(m => m.PassageId == id);
            if (meetOrdrePassage == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetOrdrePassage.Adapt<OrdrePassageDto>());
        }

        // POST: OrdrePassages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetOrdrePassages == null)
            {
                // return Problem("Entity set 'LabosContext.MeetOrdrePassages'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var meetOrdrePassage = await _context.MeetOrdrePassages.FindAsync(id);
            if (meetOrdrePassage != null)
            {
                _context.MeetOrdrePassages.Remove(meetOrdrePassage);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool MeetOrdrePassageExists(int id)
        {
          return (_context.MeetOrdrePassages?.Any(e => e.PassageId == id)).GetValueOrDefault();
        }
    }
}
