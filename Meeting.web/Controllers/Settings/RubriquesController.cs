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
    public class RubriquesController : Controller
    {
       // private readonly LabosContext _context;

        private readonly IRubriqueRepository _repository;

        private readonly ILogger<RubriquesController> _logger;

        public RubriquesController(ILogger<RubriquesController> logger, IRubriqueRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Rubriques
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Rubrique");

            TypeAdapterConfig<MeetRubrique, RubriqueDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<RubriqueDto>().ToList());
        }

        private void SetViewDataElements(RubriqueDto? valueDto)
        {
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), valueDto?.AnneeId ?? 0);
            ViewData["TyperubId"] = UtilityController.GetSelectListOfTypeRubriques(_repository.GetUnitOfWork(), valueDto?.TyperubId ?? 0);
        }

        // GET: Rubriques/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details", findObj.Adapt<RubriqueDto>());
        }

        // GET: Rubriques/Create
        public IActionResult Create()
        {
            SetViewDataElements(null);
            return PartialView("Create");
        }

        // POST: Rubriques/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("RubriqueId,AnneeId,TyperubId,Libelle,Nbmandataire,Montantroute,MontantPerson,IsOutcome,Commentaire")]*/ RubriqueDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var Rubrique = valueDto.ToEntity();

                int SavedElts = await _repository.Add(Rubrique);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

           SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // GET: Rubriques/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            var valueDto = findObj.Adapt<RubriqueDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: Rubriques/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("RubriqueId,AnneeId,TyperubId,Libelle,Nbmandataire,Montantroute,MontantPerson,IsOutcome,Commentaire")]*/ RubriqueDto valueDto)
        {
            if (id != valueDto.RubriqueId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Rubrique = valueDto.ToEntity();

                int SavedElts = await _repository.Update(id, Rubrique);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }

            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: Rubriques/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Delete", findObj.Adapt<RubriqueDto>());
        }

        // POST: Rubriques/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            int SavedElts = await _repository.Delete(id);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        //private bool MeetRubriqueExists(int id)
        //{
        //  return (_context.MeetRubriques?.Any(e => e.RubriqueId == id)).GetValueOrDefault();
        //}
    }
}
