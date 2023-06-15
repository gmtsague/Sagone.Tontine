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
using Meeting.Web.Repository;

namespace Meeting.web.Controllers.Settings
{
    public class AntennesController : Controller
    {
        //private readonly LabosContext _context;

        private readonly IAntenneRepository _repository;

        private readonly ILogger<AntennesController> _logger;

        public AntennesController(ILogger<AntennesController> logger, IAntenneRepository repository)
        {
            _logger = logger;
            // _context = context;
            _repository = repository;
        }

        // GET: Antennes
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Region");

            var resultItems = await _repository.GetAll((int?)UtilityController.GetGlobalSelectedAssociation());
            return View(resultItems.Items.AsQueryable().ProjectToType<AntenneDto>().ToList());
        }

        private void SetViewDataElements(AntenneDto? valueDto)
        {
             ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_repository.GetUnitOfWork(), valueDto?.EtabId ?? 0);
        }
        // GET: Antennes/Details/5
        public async Task<IActionResult> Details(int? IdEtab, int? IdAntenne)
        {
            var findObj = await _repository.GetDetails(IdEtab, IdAntenne);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details", findObj.Adapt<AntenneDto>());
        }

        // GET: Antennes/Create
        public IActionResult CreateView()
        {
            SetViewDataElements(null);
            return PartialView("CreateView");
        }

        // POST: Antennes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("EtabId,AntenneId,Libelle,Creationdate")]*/ AntenneDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetAntenne = valueDto.ToEntity();
                int SavedElts = await _repository.Add(meetAntenne);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

            SetViewDataElements(valueDto);
            return PartialView("CreateView", valueDto);
            //return FormResult..CreateErrorResultWithObject(valueDto);
        }

        // GET: Antennes/Edit/5
        public async Task<IActionResult> EditView(int? IdEtab, int? IdAntenne)
        {
            var findObj = await _repository.GetDetails(IdEtab, IdAntenne);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            var valueDto = findObj.Adapt<AntenneDto>();
            SetViewDataElements(valueDto);
            return PartialView("EditView", valueDto);
        }

        // POST: Antennes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int EtabId, int AntenneId, /*[Bind("EtabId,AntenneId,Libelle,Creationdate")]*/ AntenneDto valueDto)
        {
            if (AntenneId != valueDto.AntenneId && EtabId != valueDto.EtabId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                    var meetAntenne = valueDto.ToEntity();

                int SavedElts = await _repository.Update(meetAntenne.EtabId, meetAntenne.AntenneId, meetAntenne);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

            SetViewDataElements(valueDto);
            return PartialView("EditView", valueDto);
        }

        // GET: Antennes/Delete/5
        public async Task<IActionResult> DeleteView(int? IdEtab, int? IdAntenne)
        {
            var findObj = await _repository.GetDetails(IdEtab, IdAntenne);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("DeleteView",findObj.Adapt<AntenneDto>());
        }

        // POST: Antennes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int? EtabId, int? AntenneId)
        {
            var findObj = await _repository.GetDetails(EtabId, AntenneId);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            int SavedElts = await _repository.Delete(EtabId, AntenneId);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        //private bool MeetAntenneExists(int IdEtab, int IdAntenne)
        //{
        //  return (_context.MeetAntennes?.Any(e => e.EtabId == IdEtab && e.AntenneId == IdAntenne)).GetValueOrDefault();
        //}
    }
}
