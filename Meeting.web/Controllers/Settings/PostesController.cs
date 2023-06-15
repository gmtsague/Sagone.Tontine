using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting.Web.Dto;
using MeetingEntities.Models;
using Mapster;
using Meeting.web.Controllers;
using FormHelper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Meeting.Web.Repository;

namespace Meeting.Web.Controllers.Settings
{
    public class PostesController : Controller
    {
        //private readonly LabosContext _context;

        private readonly IPosteRepository _repository;

        private readonly ILogger<PostesController> _logger;

        public PostesController(ILogger<PostesController> logger, IPosteRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Postes
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Poste du bureau");

            var ViewModel = new AppPageViewModel<PosteDto>();

            var resultItems = await _repository.GetAll();
            ViewModel.DataRecords = resultItems.Items.AsQueryable().ProjectToType<PosteDto>().ToList();
            return View(ViewModel);
        }

        // GET: Postes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details", findObj.Adapt<PosteDto>());
        }

        // GET: Postes/Create
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Postes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("PosteId,Libelle,Code")]*/ PosteDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var Poste = valueDto.ToEntity();

                int SavedElts = await _repository.Add(Poste);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            return PartialView("Create", valueDto);
        }

        // GET: Postes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Edit", findObj.Adapt<PosteDto>());
        }

        // POST: Postes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("PosteId,Libelle,Code")]*/ PosteDto valueDto)
        {
            if (id != valueDto.PosteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Poste = valueDto.ToEntity();

                int SavedElts = await _repository.Update(id, Poste);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            return PartialView("Edit", valueDto);
        }

        // GET: Postes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Delete", findObj.Adapt<PosteDto>());
        }

        // POST: Postes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
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

        //private bool PosteExists(int id)
        //{
        //  return (_context.MeetPostes?.Any(e => e.PosteId == id)).GetValueOrDefault();
        //}
    }
}
