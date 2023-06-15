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
using Meeting.Web.Repository;

namespace Meeting.web.Controllers.Traitements
{
    public class EngagementsController : Controller
    {
       // private readonly LabosContext _context;

        private readonly IEngagementRepository _repository;

        private readonly ILogger<EngagementsController> _logger;

        public EngagementsController(ILogger<EngagementsController> logger, IEngagementRepository repository)
        {
            _logger = logger;
            //   _context = context;
            _repository = repository;
        }

        // GET: Engagements
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Engagement");

            SetIndexViewDataElements();

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<EngagementDto>().ToList());

            //var labosContext = _context.MeetEngagements.Include(m => m.Person).Include(m => m.Rubrique);
            //return View(await labosContext.AsNoTracking().ProjectToType<EngagementDto>().ToListAsync());
        }

        // GET: FindEngagements
        public async Task<IActionResult> FindEngagements(int PaiementStatus, int AntenneId, int PeopleId, int RubriqueId)
        {
            ViewData["TitleObj"] = new FormTitle("Engagement");

            SetIndexViewDataElements();

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);
            
            var resultItems = await _repository.FindEngagements(PaiementStatus, AntenneId, PeopleId, RubriqueId);
            return View("Index", resultItems.Items.AsQueryable().ProjectToType<EngagementDto>().ToList());

            //var labosContext = _context.MeetEngagements.Include(m => m.Rubrique)
            //                                           .Include(m => m.Person)
            //                                           .ThenInclude(m=>m.MeetInscriptions.Where(p=> p.AntenneId==AntenneId || AntenneId <= 0))                                                       
            //                                           .Where(m => ( m.PersonId == PeopleId || PeopleId <= 0 ))
            //                                           .Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
            //                                           .Where(m => PaiementStatus <= 0 || 
            //                                                       ((m.ToPay - m.Cumulverse) == 0 && PaiementStatus == 1) || 
            //                                                       ((m.ToPay - m.Cumulverse) > 0 && PaiementStatus == 2));

            //return View("Index", await labosContext.AsNoTracking().ProjectToType<EngagementDto>().ToListAsync());
        }


        private void SetIndexViewDataElements()
        {
            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            ViewData["PeopleData"] = UtilityController.GetSelectListOfRegisteredPeople(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));

            ViewData["RubriqueData"] = UtilityController.GetSelectListOfRubriques(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
        }

        private void SetViewDataElements(EngagementDto? valueDto)
        {
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_repository.GetUnitOfWork(), valueDto?.PersonId ?? 0);
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.RubriqueId ?? 0);
        }

        // GET: Engagements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", findObj.Adapt<EngagementDto>());
        }

        // GET: Engagements/Create
        public IActionResult Create()
        {
            //ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId");
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            SetViewDataElements(null);
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
            int SavedElts = await _repository.SyncEngagements(YearId);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);

            //var curYear = _context.CoreAnnees.Find(YearId);

            //if (curYear == null)
            //    //return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);

            //var AnnualEngagements = await _context.MeetEngagements
            //                             .Include(m=>m.Rubrique)
            //                             .Where(m=>m.Rubrique.AnneeId == YearId)./*AsNoTracking().*/ToListAsync();

            //var AnnualRubriques = await _context.MeetRubriques.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            //var AnnualsInscriptions = await _context.MeetInscriptions.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            //foreach(var membre in AnnualsInscriptions)
            //{
            //    foreach(var rubElt in AnnualRubriques)
            //    {
            //        if(AnnualEngagements.Find(m=>m.PersonId == membre.PersonId && m.RubriqueId == rubElt.RubriqueId) is null)
            //        {
            //            MeetEngagement newObj = new MeetEngagement()
            //            {
            //                RubriqueId = rubElt.RubriqueId,
            //                PersonId = membre.PersonId,
            //                Cumulverse = 0,
            //                CustomAmount = rubElt.MontantPerson,
            //                IsClosed = false,
            //                IsOutcome = rubElt.IsOutcome,
            //                NbReqSeances = (rubElt.TopayEachPeriode == false)? 1 : curYear.Nbdivision,
            //                ToPay = rubElt.MontantPerson * ((rubElt.TopayEachPeriode == false) ? 1 : curYear.Nbdivision)
            //            };

            //            AnnualEngagements.Add(newObj);
            //        }
            //    }
            //}
            //    _context.AttachRange(AnnualEngagements);
            //    await _context.SaveChangesAsync();
            //// return RedirectToAction(nameof(Index));
            //return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            ////  return View(valueDto);
        }

        // POST: Engagements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("EngagementId,RubriqueId,PersonId,Cumulverse,Solde,IsOutcome,IsClosed,EngagementDate")]*/ EngagementDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var Engagement = valueDto.Adapt<MeetEngagement>();
                int SavedElts = await _repository.Add(Engagement);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                //_context.Add(Engagement);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", valueDto.PersonId);
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // GET: Engagements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            //ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", findObj.PersonId);
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), findObj.RubriqueId);
            var valueDto = findObj.Adapt<EngagementDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: Engagements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("EngagementId,RubriqueId,PersonId,Cumulverse,Solde,IsOutcome,IsClosed,EngagementDate")]*/ EngagementDto valueDto)
        {
            if (id != valueDto.EngagementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var Engagement = valueDto.Adapt<MeetEngagement>(); 
                
                int SavedElts = await _repository.Update(id, Engagement);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                //try
                //{
                //    var relatedRubrique = await _context.MeetRubriques.Include(m=>m.Annee).FirstAsync(m=> m.RubriqueId == valueDto.RubriqueId);

                //    if (relatedRubrique is null)
                //        return NotFound();
                    
                //    var meetEngagement = valueDto.Adapt<MeetEngagement>();

                //    meetEngagement.CustomAmount = ((relatedRubrique.AllowCustomAmount) ? valueDto.CustomAmount : relatedRubrique.MontantPerson);
                //    meetEngagement.NbReqSeances = (relatedRubrique.TopayEachPeriode == false) ? 1 : relatedRubrique.Annee.Nbdivision;
                //    meetEngagement.ToPay = ((relatedRubrique.AllowCustomAmount) ? valueDto.CustomAmount : relatedRubrique.MontantPerson) * valueDto.NbReqSeances;

                //    _context.Update(meetEngagement);
                //    await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MeetEngagementExists(valueDto.EngagementId))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["PersonId"] = new SelectList(_context.CorePeople, "PersonId", "PersonId", valueDto.PersonId);
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: Engagements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", findObj.Adapt<EngagementDto>());
        }

        // POST: Engagements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            int SavedElts = await _repository.Delete(id);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        //private bool MeetEngagementExists(int id)
        //{
        //  return (_context.MeetEngagements?.Any(e => e.EngagementId == id)).GetValueOrDefault();
        //}
    }
}
