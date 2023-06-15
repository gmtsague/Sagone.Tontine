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
    public class BanksController : Controller
    {
        // private readonly LabosContext _context;
        private readonly IBankRepository _repository;

        private readonly ILogger<BanksController> _logger;

        public BanksController(ILogger<BanksController> logger, IBankRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Banks
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Banque");

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<BankDto>().ToList());
        }

        // GET: Banks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details", findObj.Adapt<BankDto>());
        }

        // GET: Banks/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_repository.GetUnitOfWork());
            return PartialView("Create");
        }

        // POST: Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("BankId,CountryId,Libelle,Adresse,Email,Coderib")]*/ BankDto valueDto)
        {
            if (ModelState.IsValid)
            {
                CoreBank Bank = valueDto.ToEntity();

                int SavedElts = await _repository.Add(Bank);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_repository.GetUnitOfWork(), valueDto.CountryId ?? 0);
            return PartialView("Create",valueDto);
        }

        // GET: Banks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_repository.GetUnitOfWork(), findObj.CountryId ?? 0);
            return PartialView("Edit", findObj.Adapt<BankDto>());
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("BankId,CountryId,Libelle,Adresse,Email,Coderib")]*/ BankDto valueDto)
        {
            if (id != valueDto.BankId)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            if (ModelState.IsValid)
            {
                var Bank = valueDto.ToEntity();
                int SavedElts = await _repository.Update(id, Bank);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_repository.GetUnitOfWork(), valueDto.CountryId ?? 0);
            return PartialView("Edit", valueDto);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Delete", findObj.Adapt<BankDto>());
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            int SavedElts = await _repository.Delete(id);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        //private bool CoreBankExists(int id)
        //{
        //  return (_context.CoreBanks?.Any(e => e.BankId == id)).GetValueOrDefault();
        //}
    }
}
