using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using FormHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using NuGet.Common;
using Tontine.Entities.Models;

namespace Tontine.Web.Controllers.Settings
{
    public class CoreAnneesController : Controller
    {
        private readonly LabosContext _context;

        public CoreAnneesController(LabosContext context)
        {
            _context = context;
        }

        // GET: CoreAnnees
       // [HttpPost]
        public async Task<IActionResult> Index()
        {
            var labosContext = _context.CoreAnnees.Include(c => c.IdbureauNavigation);
            return View(await labosContext.OrderByDescending(t=>t.Datedebut).ToListAsync());
        }

        public async Task<IActionResult> Getdatas()
        {
            // FOR DATATABLES INSTRUCTIONS            
            var formRequest = /*await*/ HttpContext.Request.Query; //.ReadFormAsync();

            var draw = formRequest["draw"].FirstOrDefault();
            var start = formRequest["start"].FirstOrDefault();
            var length = formRequest["length"].FirstOrDefault();
            var sortColumn = formRequest["columns[" + formRequest["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDirection = formRequest["order[0][dir]"].FirstOrDefault();
            var searchValue = formRequest["search[value]"].FirstOrDefault();
            int pageSize = length != null ? Convert.ToInt32(length) : 25;//initialement 0
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var customerData = await _context.CoreAnnees.OrderByDescending(t => t.Datedebut).ToListAsync(); // (from tempcustomer in context.Customers select tempcustomer);

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                //customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
            }
            if (!string.IsNullOrEmpty(searchValue))
            {
                customerData = (List<CoreAnnee>)customerData.Where(m => m.Libelle.Contains(searchValue)
                                            || m.Datedebut.ToString().Contains(searchValue)
                                            || m.Datefin.ToString().Contains(searchValue)
                                            || m.Idbureau.ToString().Contains(searchValue));
            }
            recordsTotal = customerData.Count();
            var data = customerData.Skip(skip).Take(pageSize).ToList();
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);

        }

        // GET: CoreAnnees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees
                .Include(c => c.IdbureauNavigation)
                .FirstOrDefaultAsync(m => m.Idannee == id);
            if (coreAnnee == null)
            {
                return NotFound();
            }
            return PartialView("Detailspartiel", coreAnnee);
            //return View(coreAnnee);
        }

        // GET: CoreAnnees/Create
        public IActionResult CreateView()
        {
            ViewData["Idbureau"] = new SelectList(_context.Bureaus, "Idbureau", "Libelle");
            return PartialView("Createpartiel");
            //return View();
        }

        // POST: CoreAnnees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[FormValidator]
        public async Task<IActionResult> Create(/*[Bind("Idannee,Idbureau,Libelle,Datedebut,Datefin,Iscurrent,Isclosed,Nbdivision")]*/ CoreAnnee coreAnnee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BuildMonths(coreAnnee);
                    _context.Add(coreAnnee);
                    await _context.SaveChangesAsync();
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult("Product saved. Please wait...", Url.Action(nameof(Index)/*"Home", "Index"*/));
                }
                ViewData["Idbureau"] = new SelectList(_context.Bureaus, "Idbureau", "Libelle", coreAnnee.Idbureau);
                return View(coreAnnee);
            }
            catch (Exception e)
            {
                return FormResult.CreateErrorResult(e.Message);
            }

        }

        private void BuildMonths(CoreAnnee coreAnnee)
        {
            if (coreAnnee != null)
            {
                string ErrorMessage = String.Format("Error in the defined End date ({0}) compared to effective End date {1}, considering the number of months {2}.", coreAnnee.Datefin, coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision), coreAnnee.Nbdivision);

                if (coreAnnee.Monthlyseances == null && coreAnnee.Nbdivision > 0)
                    coreAnnee.Monthlyseances = new List<Monthlyseance>();

                if ((coreAnnee.Nbdivision == 0) ||(coreAnnee.Nbdivision == coreAnnee?.Monthlyseances?.Count && coreAnnee.Nbdivision > 0))
                    return;

                if (coreAnnee.Datefin.Month != coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision-1).Month)
                    throw new Exception(ErrorMessage);
                    //return FormResult.CreateErrorResult(ErrorMessage);

                var startDate = coreAnnee.Datedebut;
                string MonthName = string.Empty;

                for (int i = 0; i < coreAnnee.Nbdivision; i++)
                {
                    startDate = coreAnnee.Datedebut.AddMonths(i);
                    MonthName = string.Format("{0:MMMM}-{1}", startDate, startDate.Year);
                    coreAnnee.Monthlyseances.Add(new Monthlyseance
                    {
                        Idannee = coreAnnee.Idannee,
                        Numordre = i + 1,
                        Libelle = MonthName,
                        Montantpercu = 0,
                        Totalcotise = 0,
                        Totalsortie = 0
                    });

                }
            }
        }

        // GET: CoreAnnees/Edit/5
        public async Task<IActionResult> EditView(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee == null)
            {
                return NotFound();
            }
            ViewData["Idbureau"] = new SelectList(_context.Bureaus, "Idbureau", "Libelle", coreAnnee.Idbureau);
            return PartialView("EditView", coreAnnee);
            //return View(coreAnnee);
        }

        // POST: CoreAnnees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("Idannee,Idbureau,Libelle,Datedebut,Datefin,Iscurrent,Isclosed,Nbdivision")]*/ CoreAnnee coreAnnee)
        {
            if (id != coreAnnee.Idannee)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    BuildMonths(coreAnnee);
                    _context.Update(coreAnnee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoreAnneeExists(coreAnnee.Idannee))
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
            ViewData["Idbureau"] = new SelectList(_context.Bureaus, "Idbureau", "Libelle", coreAnnee.Idbureau);
            return View(coreAnnee);
        }

        // GET: CoreAnnees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreAnnee = await _context.CoreAnnees
                .Include(c => c.IdbureauNavigation)
                .FirstOrDefaultAsync(m => m.Idannee == id);
            if (coreAnnee == null)
            {
                return NotFound();
            }
            return PartialView("Delete", coreAnnee);
           // return View(coreAnnee);
        }

        // POST: CoreAnnees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoreAnnees == null)
            {
                return Problem("Entity set 'LabosContext.CoreAnnees'  is null.");
            }
            var coreAnnee = await _context.CoreAnnees.FindAsync(id);
            if (coreAnnee != null)
            {
                _context.CoreAnnees.Remove(coreAnnee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoreAnneeExists(int id)
        {
            return (_context.CoreAnnees?.Any(e => e.Idannee == id)).GetValueOrDefault();
        }
    }
}
