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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using FormHelper;

namespace Meeting.web.Controllers.Settings
{
    public class AnneesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<AnneesController> _logger;

        public AnneesController(ILogger<AnneesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Annees
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Année");

            TypeAdapterConfig<CoreAnnee, AnneeDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.CoreAnnees.Include(c => c.Bureau).Include(c => c.Frequence).Include(c => c.PreviousYear);
            var resultItems = await labosContext.AsNoTracking().ToListAsync();
             return View(resultItems.AsQueryable().ProjectToType<AnneeDto>().ToList());
        }

        // GET: Annees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees
                .Include(c => c.Bureau)
                .Include(c => c.Frequence)
                .Include(c => c.PreviousYear)
                .FirstOrDefaultAsync(m => m.AnneeId == id);
            if (coreAnnee == null)
            {
                return NotFound();
            }

            return PartialView("Details",AnneeDto.FromEntity(coreAnnee));
        }

        // GET: Annees/Create
        public IActionResult Create()
        {
            //ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId");
            //ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId");
            //ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId");
            ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context);
            ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context);
            ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context);
            return PartialView();
        }

        // POST: Annees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("AnneeId,FrequenceId,BureauId,PreviousYearId,Libelle,Datedebut,Datefin,IsCurrent,IsClosed,Nbdivision,CopyDataFromPrevious")] AnneeDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var coreAnnee = valueDto.ToEntity();
                BuildMonthsAsync(coreAnnee);
                _context.Add(coreAnnee);
                await _context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            //ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId", valueDto.BureauId);
            //ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId", valueDto.FrequenceId);
            //ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", valueDto.PreviousYearId);
            ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, valueDto.BureauId??0);
            ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, valueDto.FrequenceId);
            ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.PreviousYearId ?? 0);
            return PartialView("Create",valueDto);
        }

        // GET: Annees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee == null)
            {
                return NotFound();
            }
            //ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId", coreAnnee.BureauId);
            //ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId", coreAnnee.FrequenceId);
            //ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", coreAnnee.PreviousYearId);
            ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, coreAnnee.BureauId ?? 0);
            ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, coreAnnee.FrequenceId);
            ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, coreAnnee.PreviousYearId ?? 0); 
            return PartialView("Edit", AnneeDto.FromEntity(coreAnnee));
        }

        // POST: Annees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("AnneeId,FrequenceId,BureauId,PreviousYearId,Libelle,Datedebut,Datefin,IsCurrent,IsClosed,Nbdivision,CopyDataFromPrevious")] AnneeDto valueDto)
        {
            if (id != valueDto.AnneeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (valueDto.BureauId == 0)
                    valueDto.BureauId = null;

               // if (valueDto.FrequenceId == 0)
                 //   valueDto.FrequenceId = null;

                if (valueDto.PreviousYearId == 0)
                    valueDto.PreviousYearId = null;

                var coreAnnee = valueDto.ToEntity();               
                try
                {
                   await BuildMonthsAsync(coreAnnee);
                    _context.Update(coreAnnee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreAnneeExists(coreAnnee.AnneeId))
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
            //ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId", valueDto.BureauId);
            //ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId", valueDto.FrequenceId);
            //ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", valueDto.PreviousYearId);
            ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, valueDto.BureauId ?? 0);
            ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, valueDto.FrequenceId);
            ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.PreviousYearId ?? 0);
            return PartialView("Edit", valueDto);
        }

        // GET: Annees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees
                .Include(c => c.Bureau)
                .Include(c => c.Frequence)
                .Include(c => c.PreviousYear)
                .FirstOrDefaultAsync(m => m.AnneeId == id);
            if (coreAnnee == null)
            {
                return NotFound();
            }

            return PartialView("Delete", AnneeDto.FromEntity(coreAnnee));
        }

        // POST: Annees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreAnnees == null)
            {
                //return Problem("Entity set 'LabosContext.CoreAnnees'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee != null)
            {
                _context.CoreAnnees.Remove(coreAnnee);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        [HttpPost, ActionName("Setdefault")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SetDefault(int id)
        {
            if (_context.CoreAnnees == null)
            {
                //return Problem("Entity set 'LabosContext.CoreAnnees'  is null.");
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee != null)
            {
                // _context.CoreAnnees.Remove(coreAnnee);
                UtilityController.SessionEntities.GlobalSelectedYear = coreAnnee.Adapt<AnneeDto>();
                //TempData["GlobalSelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear;
                TempData["SelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear.AnneeId;
                //return PartialView("_ShowGlobalEntities");
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation/*, Url.Action(nameof(Index))*/);
            }

           // await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound/*, Url.Action(nameof(Index))*/);
        }


        private async Task BuildMonthsAsync(CoreAnnee coreAnnee)
        {
            if (coreAnnee != null)
            {
                string ErrorMessage = String.Format("Error in the defined End date ({0}) compared to effective End date {1}, considering the number of months {2}.", coreAnnee.Datefin, coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision), coreAnnee.Nbdivision);

                var ExistantDivisions = await _context.CoreSubdivisions.Where(m => m.AnneeId == coreAnnee.AnneeId).ToListAsync();

                if ((coreAnnee.Nbdivision == 0) || (coreAnnee.Nbdivision == ExistantDivisions?.Count && coreAnnee.Nbdivision > 0))
                    return;

                if (coreAnnee?.Datefin.Month != coreAnnee?.Datedebut.AddMonths(coreAnnee.Nbdivision - 1).Month)
                    throw new Exception(ErrorMessage);
                //return FormResult.CreateErrorResult(ErrorMessage);

                var startDate = coreAnnee?.Datedebut;
                string MonthName = string.Empty;

                if (coreAnnee?.Nbdivision < ExistantDivisions?.Count)
                {
                   // for(int i = ((int)(ExistantDivisions?.Count-1)); i >= coreAnnee?.Nbdivision; i--)
                    {
                        _context.CoreSubdivisions.RemoveRange(ExistantDivisions.GetRange((int)(coreAnnee?.Nbdivision), (int)(ExistantDivisions?.Count - coreAnnee?.Nbdivision)));
                    }
                }

                for (int i = 0; i < coreAnnee?.Nbdivision; i++)
                {
                    startDate = coreAnnee.Datedebut.AddMonths(i);
                    MonthName = string.Format("{0:MMMM}-{1}", startDate, startDate.Value.Year);

                    if (i < ExistantDivisions?.Count)
                    {
                        var periode = ExistantDivisions.ElementAt(i);
                        periode.Libelle = MonthName;
                        periode.Numordre = i + 1;
                        periode.MonthDate = startDate.Value;
                        coreAnnee.CoreSubdivisions.Add(periode);
                    }
                    else 
                        coreAnnee.CoreSubdivisions.Add(new CoreSubdivision
                        {
                            AnneeId = coreAnnee.AnneeId,
                            Numordre = i + 1,
                            Libelle = MonthName,
                            MonthDate = startDate.Value
                        });
                }

            }
        }

        private bool CoreAnneeExists(int id)
        {
          return (_context.CoreAnnees?.Any(e => e.AnneeId == id)).GetValueOrDefault();
        }
    }
}
