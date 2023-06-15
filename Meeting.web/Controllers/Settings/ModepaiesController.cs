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
    public class ModepaiesController : Controller
    {
        //private readonly LabosContext _context;
        private readonly IModepaieRepository _repository;

        private readonly ILogger<ModepaiesController> _logger;

        public ModepaiesController(ILogger<ModepaiesController> logger, IModepaieRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Modepaies
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Mode paiement");

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<ModepaieDto>().ToList());
        }

        // GET: Modepaies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var Modepaie = await _repository.GetDetails(id);
            if (Modepaie == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", Modepaie.Adapt<ModepaieDto>());
        }

        // GET: Modepaies/Create
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Modepaies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("ModepaieId,Libelle,IsCash")]*/ ModepaieDto valueDto)
        {
            if (ModelState.IsValid)
            {
                CoreModepaie Modepaie = valueDto.ToEntity();

                int SavedElts = await _repository.Add(Modepaie);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            return PartialView("Create", valueDto);
        }

        // GET: Modepaies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var Modepaie = await _repository.GetDetails(id);
            if (Modepaie == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Edit", Modepaie.Adapt<ModepaieDto>());
        }

        // POST: Modepaies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("ModepaieId,Libelle,IsCash")]*/ ModepaieDto valueDto)
        {
            if (id != valueDto.ModepaieId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Modepaie = valueDto.ToEntity();
                int SavedElts = await _repository.Update(id, Modepaie);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            return PartialView("Edit", valueDto);
        }

        // GET: Modepaies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var Modepaie = await _repository.GetDetails(id);
            if (Modepaie == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView(Modepaie.Adapt<ModepaieDto>());
        }

        // POST: Modepaies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Modepaie = await _repository.GetDetails(id);
            if (Modepaie == null)
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

        //private bool CoreModepaieExists(int id)
        //{
        //  return (_context.CoreModepaies?.Any(e => e.ModepaieId == id)).GetValueOrDefault();
        //}
    }
}
