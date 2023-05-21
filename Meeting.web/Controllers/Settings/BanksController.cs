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

namespace Meeting.web.Controllers.Settings
{
    public class BanksController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<BanksController> _logger;

        public BanksController(ILogger<BanksController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Banks
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Banque");

            var labosContext = _context.CoreBanks.Include(c => c.Country);
            return View(await labosContext.AsQueryable().ProjectToType<BankDto>().ToListAsync());
        }

        // GET: Banks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.BankId == id);
            if (coreBank == null)
            {
                return NotFound();
            }

            return PartialView("Details", coreBank.Adapt<BankDto>());
        }

        // GET: Banks/Create
        public IActionResult Create()
        {
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context);
            return PartialView("Create");
        }

        // POST: Banks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("BankId,CountryId,Libelle,Adresse,Email,Coderib")] BankDto valueDto)
        {
            if (ModelState.IsValid)
            {
                CoreBank coreBank = valueDto.ToEntity();
                _context.Add(coreBank);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0);
            return PartialView("Create",valueDto);
        }

        // GET: Banks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks.FindAsync(id);
            if (coreBank == null)
            {
                return NotFound();
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, coreBank.CountryId ?? 0);
            return PartialView("Edit", coreBank.Adapt<BankDto>());
        }

        // POST: Banks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.

        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("BankId,CountryId,Libelle,Adresse,Email,Coderib")] BankDto valueDto)
        {
            if (id != valueDto.BankId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                 var coreBank = valueDto.ToEntity();                
                try
                {

                    _context.Update(coreBank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreBankExists(coreBank.BankId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["CountryId"] = UtilityController.GetSelectListOfCountries(_context, valueDto.CountryId ?? 0);
            return PartialView("Edit", valueDto);
        }

        // GET: Banks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreBanks == null)
            {
                return NotFound();
            }

            var coreBank = await _context.CoreBanks
                .Include(c => c.Country)
                .FirstOrDefaultAsync(m => m.BankId == id);
            if (coreBank == null)
            {
                return NotFound();
            }

            return PartialView("Delete", coreBank.Adapt<BankDto>());
        }

        // POST: Banks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreBanks == null)
            {
                //return Problem("Entity set 'LabosContext.CoreBanks'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var coreBank = await _context.CoreBanks.FindAsync(id);
            if (coreBank != null)
            {
                _context.CoreBanks.Remove(coreBank);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool CoreBankExists(int id)
        {
          return (_context.CoreBanks?.Any(e => e.BankId == id)).GetValueOrDefault();
        }
    }
}
