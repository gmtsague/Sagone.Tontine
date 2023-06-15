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

            var resultItems = await _repository.GetAll();
             return View(resultItems.Items.AsQueryable().ProjectToType<AnneeDto>().ToList());
        }

        private void SetViewDataElements(AnneeDto? valueDto)
        {
            ViewData["BureauId"] = UtilityController.GetSelectListOfBureaux(_repository.GetUnitOfWork(), valueDto?.BureauId ?? 0);
            ViewData["FrequenceId"] = UtilityController.GetSelectListOfFrequenceDivisions(_repository.GetUnitOfWork(), valueDto?.FrequenceId ?? 0);
            ViewData["PreviousYearId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), valueDto?.PreviousYearId ?? 0, valueDto?.AnneeId ?? 0);
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

        //private bool CoreAnneeExists(int id)
        //{
        //  return (_context.CoreAnnees?.Any(e => e.AnneeId == id)).GetValueOrDefault();
        //}
    }
}
