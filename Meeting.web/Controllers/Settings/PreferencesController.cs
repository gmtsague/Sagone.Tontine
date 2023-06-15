using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.Web.Dto;
using Meeting.Web.Repository;
using Mapster;
using FormHelper;

namespace Meeting.web.Controllers.Settings
{
    public class PreferencesController : Controller
    {
       // private readonly LabosContext _context;

        private readonly IPreferencesRepository _repository;

        private readonly ILogger<PreferencesController> _logger;

        public PreferencesController(ILogger<PreferencesController> logger, IPreferencesRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: Preferences
        public async Task<IActionResult> Index()
        {
            //var labosContext = _context.MeetPreferences.Include(m => m.Setting);
            //return View(await labosContext.ToListAsync());
            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<PreferenceDto>().ToList());
        }

        // GET: Preferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return View(findObj.Adapt<PreferenceDto>());
        }

        // GET: Preferences/Create
        public IActionResult Create()
        {
            //ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId");
            return View();
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("SettingId,TauxInteretMensuel,TauxInteretPenalite,TauxPenaliteCotisation,EnableAutoGenPresence,EnableSigningOutcome,EnableMaxDelayPenalites,EnableAutoDispatchIncome,EnableFixedAmountFees,EnableSecoursInsurance,EnableFixedFeesByAnten")]*/ PreferenceDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var Preference = valueDto.ToEntity();

                int SavedElts = await _repository.Add(Preference);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            //ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", meetPreference.SettingId);
            return View(valueDto);
        }

        // GET: Preferences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            //ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", findObj.SettingId);
            return View(findObj.Adapt<PreferenceDto>());
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,TauxInteretMensuel,TauxInteretPenalite,TauxPenaliteCotisation,EnableAutoGenPresence,EnableSigningOutcome,EnableMaxDelayPenalites,EnableAutoDispatchIncome,EnableFixedAmountFees,EnableSecoursInsurance,EnableFixedFeesByAnten")] PreferenceDto valueDto)
        {
            if (id != valueDto.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var preference = valueDto.ToEntity();
                int SavedElts = await _repository.Update(id, preference);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            //ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", meetPreference.SettingId);
            return View(valueDto);
        }

        // GET: Preferences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return View(findObj.Adapt<PreferenceDto>());
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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

        //private bool MeetPreferenceExists(int id)
        //{
        //  return (_context.MeetPreferences?.Any(e => e.SettingId == id)).GetValueOrDefault();
        //}
    }
}
