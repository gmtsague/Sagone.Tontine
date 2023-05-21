using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;

namespace Meeting.web.Controllers.Settings
{
    public class AnnualSettingsController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<AnnualSettingsController> _logger;

        public AnnualSettingsController(ILogger<AnnualSettingsController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: AnnualSettings
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CoreAnnualSettings.Include(c => c.Annee).Include(c => c.Etab);
            return View(await labosContext.ToListAsync());
        }

        // GET: AnnualSettings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreAnnualSettings == null)
            {
                return NotFound();
            }

            var coreAnnualSetting = await _context.CoreAnnualSettings
                .Include(c => c.Annee)
                .Include(c => c.Etab)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (coreAnnualSetting == null)
            {
                return NotFound();
            }

            return View(coreAnnualSetting);
        }

        // GET: AnnualSettings/Create
        public IActionResult Create()
        {
            ViewData["AnneeId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId");
            ViewData["EtabId"] = new SelectList(_context.CoreEtablissements, "EtabId", "EtabId");
            return View();
        }

        // POST: AnnualSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SettingId,CreateUid,UpdateUid,CreateAt,UpdateAt,AnneeId,EtabId,MaxAllowPhotoLiens,Copyengagements,Copymembers")] CoreAnnualSetting coreAnnualSetting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coreAnnualSetting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnneeId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", coreAnnualSetting.AnneeId);
            ViewData["EtabId"] = new SelectList(_context.CoreEtablissements, "EtabId", "EtabId", coreAnnualSetting.EtabId);
            return View(coreAnnualSetting);
        }

        // GET: AnnualSettings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreAnnualSettings == null)
            {
                return NotFound();
            }

            var coreAnnualSetting = await _context.CoreAnnualSettings.FindAsync(id);
            if (coreAnnualSetting == null)
            {
                return NotFound();
            }
            ViewData["AnneeId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", coreAnnualSetting.AnneeId);
            ViewData["EtabId"] = new SelectList(_context.CoreEtablissements, "EtabId", "EtabId", coreAnnualSetting.EtabId);
            return View(coreAnnualSetting);
        }

        // POST: AnnualSettings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SettingId,CreateUid,UpdateUid,CreateAt,UpdateAt,AnneeId,EtabId,MaxAllowPhotoLiens,Copyengagements,Copymembers")] CoreAnnualSetting coreAnnualSetting)
        {
            if (id != coreAnnualSetting.SettingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coreAnnualSetting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreAnnualSettingExists(coreAnnualSetting.SettingId))
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
            ViewData["AnneeId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId", coreAnnualSetting.AnneeId);
            ViewData["EtabId"] = new SelectList(_context.CoreEtablissements, "EtabId", "EtabId", coreAnnualSetting.EtabId);
            return View(coreAnnualSetting);
        }

        // GET: AnnualSettings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreAnnualSettings == null)
            {
                return NotFound();
            }

            var coreAnnualSetting = await _context.CoreAnnualSettings
                .Include(c => c.Annee)
                .Include(c => c.Etab)
                .FirstOrDefaultAsync(m => m.SettingId == id);
            if (coreAnnualSetting == null)
            {
                return NotFound();
            }

            return View(coreAnnualSetting);
        }

        // POST: AnnualSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreAnnualSettings == null)
            {
                return Problem("Entity set 'LabosContext.CoreAnnualSettings'  is null.");
            }
            var coreAnnualSetting = await _context.CoreAnnualSettings.FindAsync(id);
            if (coreAnnualSetting != null)
            {
                _context.CoreAnnualSettings.Remove(coreAnnualSetting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoreAnnualSettingExists(int id)
        {
          return (_context.CoreAnnualSettings?.Any(e => e.SettingId == id)).GetValueOrDefault();
        }
    }
}
