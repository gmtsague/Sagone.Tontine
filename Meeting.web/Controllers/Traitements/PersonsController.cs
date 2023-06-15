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

namespace Meeting.web.Controllers.Traitements
{
    public class PersonsController : Controller
    {
       // private readonly LabosContext _context; 
        
        private readonly IPersonRepository _repository;

        private readonly ILogger<PersonsController> _logger;

        public PersonsController(ILogger<PersonsController> logger, IPersonRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Persons
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Personne");

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<PersonDto>().ToList());
        }

        private void SetViewDataElements(PersonDto? valueDto)
        {
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_repository.GetUnitOfWork(), valueDto?.CountryId ?? 0);
            ViewData["EtabId"] = UtilityController.GetSelectListOfEtablissements(_repository.GetUnitOfWork(), valueDto?.EtabId ?? 0);
        }

        // GET: Persons/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", findObj.Adapt<PersonDto>());
        }

        // GET: Persons/Create
        public IActionResult Create()
        {
            SetViewDataElements(null);
            return PartialView("Create");
        }

        // POST: Persons/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("PersonId,CountryId,EtabId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,AdhesionDate,Nocni,CniExpireDate,IsActive,IsVisible,AnneePromo")]*/ PersonDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var Person = valueDto.ToEntity();
                int SavedElts = await _repository.Add(Person);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // GET: Persons/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            var valueDto = findObj.Adapt<PersonDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: Persons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("PersonId,CountryId,EtabId,Nom,Prenom,Datenais,Lieunais,Sexe,Email,Adresse,AdhesionDate,Nocni,CniExpireDate,IsActive,IsVisible,AnneePromo")]*/ PersonDto valueDto)
        {
            if (id != valueDto.PersonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Person = valueDto.ToEntity();
                int SavedElts = await _repository.Update(id, Person);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: Persons/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", findObj.Adapt<PersonDto>());
        }

        // POST: Persons/Delete/5
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

        //private bool CorePersonExists(int id)
        //{
        //  return (_context.CorePeople?.Any(e => e.PersonId == id)).GetValueOrDefault();
        //}
    }
}
