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
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using FormHelper;

namespace Meeting.web.Controllers.Traitements
{
    public class EngagementsController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<EngagementsController> _logger;

        public EngagementsController(ILogger<EngagementsController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Engagements
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Engagement");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            ViewData["PeopleData"] = UtilityController.GetSelectListOfPeople(_context);

            ViewData["RubriqueData"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetEngagements.Include(m => m.Person).Include(m => m.Rubrique);
            return View(await labosContext.AsNoTracking().ProjectToType<EngagementDto>().ToListAsync());
        }

        // GET: FindEngagements
        public async Task<IActionResult> FindEngagements(int PaiementStatus, int AntenneId, int PeopleId, int RubriqueId)
        {
            ViewData["TitleObj"] = new FormTitle("Engagement");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            ViewData["PeopleData"] = UtilityController.GetSelectListOfRegisteredPeople(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));

            ViewData["RubriqueData"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);
            
            var labosContext = _context.MeetEngagements.Include(m => m.Rubrique)
                                                       .Include(m => m.Person)
                                                       .ThenInclude(m=>m.MeetInscriptions.Where(p=> p.AntenneId==AntenneId || AntenneId <= 0))                                                       
                                                       .Where(m => ( m.PersonId == PeopleId || PeopleId <= 0 ))
                                                       .Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
                                                       .Where(m => PaiementStatus <= 0 || 
                                                                   ((m.ToPay - m.Cumulverse) == 0 && PaiementStatus == 1) || 
                                                                   ((m.ToPay - m.Cumulverse) > 0 && PaiementStatus == 2));

            return View("Index", await labosContext.AsNoTracking().ProjectToType<EngagementDto>().ToListAsync());
        }

        // GET: Engagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetEngagements == null)
            {
                return NotFound();
            }

            var meetEngagement = await _context.MeetEngagements
                .Include(m => m.Person)
                .Include(m => m.Rubrique)
                .FirstOrDefaultAsync(m => m.EngagementId == id);
            if (meetEngagement == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetEngagement.Adapt<EngagementDto>());
        }

        // GET: Engagements/Create
        public IActionResult Create()
        {
            ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId");
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return PartialView("Create");
        }

        // POST: Engagements/RefreshEngagements
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SyncEngagements([FromForm]int YearId)
        {
            var curYear = _context.CoreAnnees.Find(YearId);

            if (curYear == null)
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);

            var AnnualEngagements = await _context.MeetEngagements
                                         .Include(m=>m.Rubrique)
                                         .Where(m=>m.Rubrique.AnneeId == YearId)./*AsNoTracking().*/ToListAsync();

            var AnnualRubriques = await _context.MeetRubriques.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();
            
            var AnnualsInscriptions = await _context.MeetInscriptions.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            foreach(var membre in AnnualsInscriptions)
            {
                foreach(var rubElt in AnnualRubriques)
                {
                    if(AnnualEngagements.Find(m=>m.PersonId == membre.PersonId && m.RubriqueId == rubElt.RubriqueId) is null)
                    {
                        MeetEngagement newObj = new MeetEngagement()
                        {
                            RubriqueId = rubElt.RubriqueId,
                            PersonId = membre.PersonId,
                            Cumulverse = 0,
                            CustomAmount = rubElt.MontantPerson,
                            IsClosed = false,
                            IsOutcome = rubElt.IsOutcome,
                            NbReqSeances = (rubElt.TopayEachPeriode == false)? 1 : curYear.Nbdivision,
                            ToPay = rubElt.MontantPerson * ((rubElt.TopayEachPeriode == false) ? 1 : curYear.Nbdivision)
                        };
                        
                        AnnualEngagements.Add(newObj);
                    }
                }
            }
                _context.AttachRange(AnnualEngagements);
                await _context.SaveChangesAsync();
            // return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            //  return View(valueDto);
        }

        // POST: Engagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("EngagementId,RubriqueId,PersonId,Cumulverse,Solde,IsOutcome,IsClosed,EngagementDate")] EngagementDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var meetEngagement = valueDto.Adapt<MeetEngagement>();
                _context.Add(meetEngagement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", valueDto.PersonId);
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            return PartialView("Create", valueDto);
        }

        // GET: Engagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetEngagements == null)
            {
                return NotFound();
            }

            var meetEngagement = await _context.MeetEngagements.FindAsync(id);
            if (meetEngagement == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", meetEngagement.PersonId);
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetEngagement.RubriqueId);
            return PartialView("Edit", meetEngagement.Adapt<EngagementDto>());
        }

        // POST: Engagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("EngagementId,RubriqueId,PersonId,Cumulverse,Solde,IsOutcome,IsClosed,EngagementDate")] EngagementDto valueDto)
        {
            if (id != valueDto.EngagementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var relatedRubrique = await _context.MeetRubriques.Include(m=>m.Annee).FirstAsync(m=> m.RubriqueId == valueDto.RubriqueId);

                    if (relatedRubrique is null)
                        return NotFound();
                    
                    var meetEngagement = valueDto.Adapt<MeetEngagement>();

                    meetEngagement.CustomAmount = ((relatedRubrique.AllowCustomAmount) ? valueDto.CustomAmount : relatedRubrique.MontantPerson);
                    meetEngagement.NbReqSeances = (relatedRubrique.TopayEachPeriode == false) ? 1 : relatedRubrique.Annee.Nbdivision;
                    meetEngagement.ToPay = ((relatedRubrique.AllowCustomAmount) ? valueDto.CustomAmount : relatedRubrique.MontantPerson) * valueDto.NbReqSeances;

                    _context.Update(meetEngagement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetEngagementExists(valueDto.EngagementId))
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
            ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", valueDto.PersonId);
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            return PartialView("Edit", valueDto);
        }

        // GET: Engagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetEngagements == null)
            {
                return NotFound();
            }

            var meetEngagement = await _context.MeetEngagements
                .Include(m => m.Person)
                .Include(m => m.Rubrique)
                .FirstOrDefaultAsync(m => m.EngagementId == id);
            if (meetEngagement == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetEngagement.Adapt<EngagementDto>());
        }

        // POST: Engagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetEngagements == null)
            {
                return Problem("Entity set 'LabosContext.MeetEngagements'  is null.");
            }
            var meetEngagement = await _context.MeetEngagements.FindAsync(id);
            if (meetEngagement != null)
            {
                _context.MeetEngagements.Remove(meetEngagement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetEngagementExists(int id)
        {
          return (_context.MeetEngagements?.Any(e => e.EngagementId == id)).GetValueOrDefault();
        }
    }
}
