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

namespace Meeting.web.Controllers.Traitements
{
    public class SeancesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<SeancesController> _logger;

        public SeancesController(ILogger<SeancesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Seances
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Séance de reunion");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            var labosContext = _context.MeetSeances.Include(m => m.CoreSubdivision)
                                                   .Include(m => m.MeetAntenne)
                                                   .Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) && m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return View(await labosContext.AsNoTracking().ProjectToType<SeanceDto>().ToListAsync());
        }

        // GET: Seances
        public async Task<IActionResult> SeancesByAntenne(int Id)
        {
            ViewData["TitleObj"] = new FormTitle("Séance de reunion");

            var labosContext = _context.MeetSeances.Include(m => m.CoreSubdivision)
                                                   .Include(m => m.MeetAntenne)
                                                   .Where(m => (Id <= 0 || m.AntenneId == Id) && m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));

            return PartialView("_PartialGridViewSeances", await labosContext.AsNoTracking().ProjectToType<SeanceDto>().ToListAsync());
        }

        // GET: Seances
        public async Task<IActionResult> DetailsPresences(int seanceId)
        {
            ViewData["TitleObj"] = new FormTitle("Séance de reunion");

            /*var labosContext = await _context.MeetSeances.Include(m => m.MeetPresences)
                                                    .ThenInclude(m=>m.IdinscritNavigation)
                                                    .ThenInclude(m=>m.Person)                                                   
                                                   .Where(m=>m.SeanceId == seanceId).AsNoTracking().Select(m=>m.MeetPresences)
                                                   .ProjectToType<PresenceDto>().ToListAsync();
            */
            var labosContext = await _context.MeetPresences.Include(m => m.Seance)
                                                            .Include(m => m.IdinscritNavigation)
                                                            .ThenInclude(m => m.Person)
                                                            .Where(m => m.SeanceId == seanceId)
                                                            .AsNoTracking()
                                                            .ProjectToType<PresenceDto>().ToListAsync();
            return PartialView("_PartialDetailsPresences",  labosContext);
        }        
        
        // GET: Seances/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetSeances == null)
            {
                return NotFound();
            }

            var meetSeance = await _context.MeetSeances
                .Include(m => m.CoreSubdivision)
                .Include(m => m.MeetAntenne)
                .FirstOrDefaultAsync(m => m.SeanceId == id);
            if (meetSeance == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetSeance.Adapt<SeanceDto>());
        }

        // GET: Seances/Create
        public IActionResult Create()
        {
           // ViewData["AnneeId"] = new SelectList(_context.CoreSubdivisions, "AnneeId", "AnneeId");
           // ViewData["EtabId"] = new SelectList(_context.MeetAntennes, "EtabId", "EtabId");

            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0));
            var newObj = new SeanceDto()
            {
                AnneeId = Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0),
                EtabId = Convert.ToInt32(TempData.Peek("SelectedEtab") ?? 0)
            };
            return PartialView("Create", newObj);
        }

        // POST: Seances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("SeanceId,AnneeId,DivisionId,EtabId,AntenneId,Opendate,Closedate,TotalEntrees,TotalSorties,Depensecollation,Compterendu,Status")] SeanceDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetSeance = valueDto.ToEntity();
                meetSeance.Opendate = DateTime.Now;
                BuildSeanceMembers(meetSeance);
                _context.Add(meetSeance);
                int savedEntities = await _context.SaveChangesAsync();
                //  return RedirectToAction(nameof(Index));
                if (savedEntities >= 1)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));

            }

            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), valueDto.AntenneId ?? 0 );
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0), valueDto.DivisionId);

            return PartialView("Create", valueDto);
        }

        // GET: Seances/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetSeances == null)
            {
                return NotFound();
            }

            var meetSeance = await _context.MeetSeances.FindAsync(id);
            if (meetSeance == null)
            {
                return NotFound();
            }
            //ViewData["AnneeId"] = new SelectList(_context.CoreSubdivisions, "AnneeId", "AnneeId", meetSeance.AnneeId);
            //ViewData["EtabId"] = new SelectList(_context.MeetAntennes, "EtabId", "EtabId", meetSeance.EtabId);

            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), meetSeance.AntenneId ?? 0);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0), meetSeance.DivisionId);

            return PartialView("Edit", meetSeance.Adapt<SeanceDto>());
        }

        // POST: Seances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("SeanceId,AnneeId,DivisionId,EtabId,AntenneId,Opendate,Closedate,TotalEntrees,TotalSorties,Depensecollation,Compterendu,Status")] SeanceDto valueDto)
        {
            if (id != valueDto.SeanceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                int savedEntities = 0;
                try
                {
                    //var meetSeance = valueDto.ToEntity();
                    var meetSeance = await _context.MeetSeances.Include(m => m.MeetPresences).FirstAsync(m => m.SeanceId == valueDto.SeanceId);
                    if (meetSeance == null)
                    {
                        return NotFound();
                    }
                    (meetSeance.Status, meetSeance.AntenneId, meetSeance.AnneeId, meetSeance.DivisionId, meetSeance.EtabId) = (valueDto.Status, valueDto.AntenneId, valueDto.AnneeId, valueDto.DivisionId, valueDto.EtabId);
                    BuildSeanceMembers(meetSeance);
                    _context.Update(meetSeance);
                    savedEntities = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetSeanceExists(valueDto.SeanceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                if (savedEntities >= 1)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));

            }
            // ViewData["AnneeId"] = new SelectList(_context.CoreSubdivisions, "AnneeId", "AnneeId", valueDto.AnneeId);
            // ViewData["EtabId"] = new SelectList(_context.MeetAntennes, "EtabId", "EtabId", valueDto.EtabId);
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), valueDto.AntenneId ?? 0);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0), valueDto.DivisionId);

            return PartialView("Edit", valueDto);
        }

        // GET: Seances/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetSeances == null)
            {
                return NotFound();
            }

            var meetSeance = await _context.MeetSeances
                .Include(m => m.CoreSubdivision)
                .Include(m => m.MeetAntenne)
                .FirstOrDefaultAsync(m => m.SeanceId == id);
            if (meetSeance == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetSeance.Adapt<SeanceDto>());
        }

        // POST: Seances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetSeances == null)
            {
                return Problem("Entity set 'LabosContext.MeetSeances'  is null.");
            }
            var meetSeance = await _context.MeetSeances.FindAsync(id);
            if (meetSeance != null)
            {
                _context.MeetSeances.Remove(meetSeance);
            }

            int savedEntities = await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            if (savedEntities >= 1)
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        private void BuildSeanceMembers(MeetSeance meetseance)
        {
            if (meetseance == null)
                return;
            //Get list of annual registered members
            var registeredMembers = GetAnnualRegisteredMembersAsync(meetseance.AnneeId, meetseance.AntenneId ?? 0);
            foreach(var member in registeredMembers.Result)
            {
                if (meetseance.MeetPresences.FirstOrDefault(m => m.Idinscrit == member.Idinscrit) == null)
                {
                    meetseance.MeetPresences.Add(new MeetPresence()
                    {
                        Idinscrit = member.Idinscrit,
                        IsAbsent = false,
                        Globalverse = 0
                    });
                }                
            }
        }

        private async Task<IList<MeetInscription>> GetAnnualRegisteredMembersAsync(int yearId, int antenne)
        {
            return await _context.MeetInscriptions
                                 .Where(m => m.AnneeId == yearId && ((antenne == 0) ? true : m.AntenneId == antenne))
                                 .AsNoTracking().ToListAsync();
        }

        private bool MeetSeanceExists(int id)
        {
          return (_context.MeetSeances?.Any(e => e.SeanceId == id)).GetValueOrDefault();
        }
    }
}
