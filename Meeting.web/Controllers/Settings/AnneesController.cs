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
using Meeting.Web.Repository;
using System.ComponentModel.DataAnnotations;

namespace Meeting.web.Controllers.Settings
{
    public class AnneesController : Controller
    {
       // private readonly LabosContext _context;

        private readonly ILogger<AnneesController> _logger;

        private readonly IAnneeRepository _repository;

        public AnneesController(ILogger<AnneesController> logger, /*LabosContext context,*/ IAnneeRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Annees
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Année");

            TypeAdapterConfig<CoreAnnee, AnneeDto>.NewConfig().MaxDepth(3);

            // var labosContext = _context.CoreAnnees.Include(c => c.Bureau).Include(c => c.Frequence).Include(c => c.PreviousYear);
            // var resultItems = await labosContext.AsNoTracking().ToListAsync();

            var resultItems = await _repository.GetAll();
             return View(resultItems.Items.AsQueryable().ProjectToType<AnneeDto>().ToList());
        }

        private void SetViewDataElements(AnneeDto? valueDto)
        {
            //if (valueDto == null)
            //{
            //    ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context);
            //    ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context);
            //    ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork());
            //}
            //else
            {
                ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_repository.GetUnitOfWork(), valueDto?.BureauId ?? 0);
                ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_repository.GetUnitOfWork(), valueDto?.FrequenceId ?? 0);
                ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), valueDto?.PreviousYearId ?? 0, valueDto?.AnneeId ?? 0);

            }
        }

        // GET: Annees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var coreAnnee = await _repository.GetDetails(id);
            if (coreAnnee == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details",AnneeDto.FromEntity(coreAnnee));
        }

        // GET: Annees/Create
        public IActionResult Create()
        {
            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context);
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context);
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context);

            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_repository.GetUnitOfWork());
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_repository.GetUnitOfWork());
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), 0, true);

            SetViewDataElements(null);
            return PartialView();
        }

        // POST: Annees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([FromBody, Required] AnneeDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var coreAnnee = valueDto.ToEntity();
                int SavedElts = await _repository.Add(coreAnnee);

                if (SavedElts > 0)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, valueDto.BureauId??0);
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, valueDto.FrequenceId);
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.PreviousYearId ?? 0);

            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, valueDto.BureauId??0);
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, valueDto.FrequenceId);
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), valueDto.PreviousYearId ?? 0, true);           
            SetViewDataElements(valueDto);
            return PartialView("Create",valueDto);
        }

        // GET: Annees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var coreAnnee = await _repository.GetDetails(id);
            if (coreAnnee == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, coreAnnee.BureauId ?? 0);
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, coreAnnee.FrequenceId);
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, coreAnnee.PreviousYearId ?? 0); 
            var valueDto = AnneeDto.FromEntity(coreAnnee);
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: Annees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [FromBody] AnneeDto valueDto)
        {
            if (id != valueDto.AnneeId)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            if (ModelState.IsValid)
            {
                var coreAnnee = valueDto.ToEntity();
                int SavedElts = await _repository.Update(id, coreAnnee);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

            //ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_context, valueDto.BureauId ?? 0);
            //ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_context, valueDto.FrequenceId);
            //ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.PreviousYearId ?? 0);

            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: Annees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var coreAnnee = await _repository.GetDetails(id);
            if (coreAnnee == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Delete", AnneeDto.FromEntity(coreAnnee));
        }

        // POST: Annees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var coreAnnee = await _repository.GetDetails(id);
            if (coreAnnee == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            int SavedElts = await _repository.Delete(id);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Setdefault")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SetDefault(int id)
        {
           bool SavedElts = await _repository.SetDefault(id);
            if (SavedElts)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.SetAsDefaultOperationFailed);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Setcurrent")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SetAsCurrent(int id)
        {
        //    if (_context.CoreAnnees == null)
        //    {
        //        //return Problem("Entity set 'LabosContext.CoreAnnees'  is null.");
        //        return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
        //    }
        //    var coreAnnee = await _context.CoreAnnees.FindAsync(id);
        //    if (coreAnnee != null)
        //    {
        //        UtilityController.SessionEntities.GlobalSelectedYear = coreAnnee.Adapt<AnneeDto>();
        //        //TempData["GlobalSelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear;
        //        TempData["SelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear.AnneeId;
        //        return FormResult.CreateSuccessResult(UtilityController.SuccessOperation);
        //    }

            var coreAnnee = await _repository.GetDetails(id);
            if (coreAnnee == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            UtilityController.SessionEntities.GlobalSelectedYear = coreAnnee.Adapt<AnneeDto>();
            //TempData["GlobalSelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear;
            TempData["SelectedYear"] = UtilityController.SessionEntities.GlobalSelectedYear.AnneeId;
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation);
        }

        //private async Task BuildMonthsAsync(CoreAnnee coreAnnee)
        //{
        //    if (coreAnnee != null)
        //    {
        //        string ErrorMessage = String.Format("Error in the defined End date ({0}) compared to effective End date {1}, considering the number of months {2}.", coreAnnee.Datefin, coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision), coreAnnee.Nbdivision);

        //        var ExistantDivisions = await _context.CoreSubdivisions.Where(m => m.AnneeId == coreAnnee.AnneeId).ToListAsync();

        //        if ((coreAnnee.Nbdivision == 0) || (coreAnnee.Nbdivision == ExistantDivisions?.Count && coreAnnee.Nbdivision > 0))
        //            return;

        //        if (coreAnnee?.Datefin.Month != coreAnnee?.Datedebut.AddMonths(coreAnnee.Nbdivision - 1).Month)
        //            throw new Exception(ErrorMessage);
        //        //return FormResult.CreateErrorResult(ErrorMessage);

        //        var startDate = coreAnnee?.Datedebut;
        //        string MonthName = string.Empty;

        //        if (coreAnnee?.Nbdivision < ExistantDivisions?.Count)
        //        {
        //           // for(int i = ((int)(ExistantDivisions?.Count-1)); i >= coreAnnee?.Nbdivision; i--)
        //            {
        //                _context.CoreSubdivisions.RemoveRange(ExistantDivisions.GetRange((int)(coreAnnee?.Nbdivision), (int)(ExistantDivisions?.Count - coreAnnee?.Nbdivision)));
        //            }
        //        }

        //        for (int i = 0; i < coreAnnee?.Nbdivision; i++)
        //        {
        //            startDate = coreAnnee.Datedebut.AddMonths(i);
        //            MonthName = string.Format("{0:MMMM}-{1}", startDate, startDate.Value.Year);

        //            if (i < ExistantDivisions?.Count)
        //            {
        //                var periode = ExistantDivisions.ElementAt(i);
        //                periode.Libelle = MonthName;
        //                periode.Numordre = i + 1;
        //                periode.MonthDate = startDate.Value;
        //                coreAnnee.CoreSubdivisions.Add(periode);
        //            }
        //            else 
        //                coreAnnee.CoreSubdivisions.Add(new CoreSubdivision
        //                {
        //                    AnneeId = coreAnnee.AnneeId,
        //                    Numordre = i + 1,
        //                    Libelle = MonthName,
        //                    MonthDate = startDate.Value
        //                });
        //        }

        //    }
        //}

        //private bool CoreAnneeExists(int id)
        //{
        //  return (_context.CoreAnnees?.Any(e => e.AnneeId == id)).GetValueOrDefault();
        //}
    }
}
