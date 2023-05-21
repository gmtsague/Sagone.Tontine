using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.Web.Dto;

namespace Meeting.web.Controllers.Settings
{
    public class PreferencesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<PreferencesController> _logger;

        public PreferencesController(ILogger<PreferencesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Preferences
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.MeetPreferences.Include(m => m.Setting);
            return View(await labosContext.ToListAsync());
        }

        // GET: Preferences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetPreferences == null)
            {
                return NotFound();
            }

            var meetPreference = await _context.MeetPreferences
                .Include(m => m.Setting)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (meetPreference == null)
            {
                return NotFound();
            }

            return View(meetPreference);
        }

        // GET: Preferences/Create
        public IActionResult Create()
        {
            ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId");
            return View();
        }

        // POST: Preferences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettingId,TauxInteretMensuel,TauxInteretPenalite,TauxPenaliteCotisation,EnableAutoGenPresence,EnableSigningOutcome,EnableMaxDelayPenalites,EnableAutoDispatchIncome,EnableFixedAmountFees,EnableSecoursInsurance,EnableFixedFeesByAnten")] PreferenceDto meetPreference)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meetPreference);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", meetPreference.SettingId);
            return View(meetPreference);
        }

        // GET: Preferences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetPreferences == null)
            {
                return NotFound();
            }

            var meetPreference = await _context.MeetPreferences.FindAsync(id);
            if (meetPreference == null)
            {
                return NotFound();
            }
            ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", meetPreference.SettingId);
            return View(meetPreference);
        }

        // POST: Preferences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,TauxInteretMensuel,TauxInteretPenalite,TauxPenaliteCotisation,EnableAutoGenPresence,EnableSigningOutcome,EnableMaxDelayPenalites,EnableAutoDispatchIncome,EnableFixedAmountFees,EnableSecoursInsurance,EnableFixedFeesByAnten")] PreferenceDto meetPreference)
        {
            if (id != meetPreference.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meetPreference);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetPreferenceExists(meetPreference.SettingId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["SettingId"] = new SelectList(_context.CoreAnnualSettings, "SettingId", "SettingId", meetPreference.SettingId);
            return View(meetPreference);
        }

        // GET: Preferences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetPreferences == null)
            {
                return NotFound();
            }

            var meetPreference = await _context.MeetPreferences
                .Include(m => m.Setting)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (meetPreference == null)
            {
                return NotFound();
            }

            return View(meetPreference);
        }

        // POST: Preferences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetPreferences == null)
            {
                return Problem("Entity set 'LabosContext.MeetPreferences'  is null.");
            }
            var meetPreference = await _context.MeetPreferences.FindAsync(id);
            if (meetPreference != null)
            {
                _context.MeetPreferences.Remove(meetPreference);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetPreferenceExists(int id)
        {
          return (_context.MeetPreferences?.Any(e => e.SettingId == id)).GetValueOrDefault();
        }
    }
}
