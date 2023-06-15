using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting.Web.Dto;
using MeetingEntities.Models;
using Meeting.web.Controllers.Traitements;
using Mapster;
using Meeting.web.Controllers;
using FormHelper;
using Meeting.Web.Repository;

namespace Meeting.Web.Controllers.Traitements
{
    public class PresencesController : Controller
    {
        //private readonly LabosContext _context;

        private readonly IPresencesRepository _repository;

        private readonly ILogger<PresencesController> _logger;

        public PresencesController(ILogger<PresencesController> logger, IPresencesRepository repository)
        {
            _logger = logger;
            // _context = context;
            _repository = repository;
        }

        // GET: Presences
        public async Task<IActionResult> Index()
        {
            //var labosContext = _context.MeetPresences.Include(p => p.Seance).AsNoTracking().ProjectToType<PresenceDto>();
            //return View(await labosContext.ToListAsync());

            var resultItems = await _repository.GetAll();
            return View(resultItems.Items.AsQueryable().ProjectToType<PresenceDto>().ToList());
        }

        private void SetViewDataElements(PresenceDto? valueDto)
        {
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_repository.GetUnitOfWork(), 
                                                                            Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), 
                                                                            Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.SeanceId ?? 0);
        }

        // GET: Presences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //if (id == null || _context.MeetPresences == null)
            //{
            //    // return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            //var presence = await _context.MeetPresences
            //    .Include(p => p.Seance.CoreSubdivision)
            //    .Include(m => m.IdinscritNavigation.Person)
            //    .Include(m => m.IdinscritNavigation.MeetAntenne)
            //    //.ThenInclude(m => m.Person)
            //    .Include(p=> p.MeetEntreeCaisses)
            //    .ThenInclude(p=>p.Engagement)
            //    .ThenInclude(p=>p.Rubrique)
            //    .FirstOrDefaultAsync(m => m.PresenceId == id);
            //if (presence == null)
            //{
            //    // return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            var Resultat = findObj.Adapt<PresenceDto>();
            Resultat.EntreeCaisses = findObj.MeetEntreeCaisses.Adapt<List<EntreeCaisseDto>>();
            return PartialView("Details", Resultat);
        }

        // GET: Presences/Create
        public IActionResult Create()
        {
            // ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            SetViewDataElements(null);
            //Task<IActionResult> FindEngagements(int PaiementStatus, int AntenneId, int PeopleId, int RubriqueId)

                return View(); 
        }

        // POST: Presences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("PresenceId,SeanceId,Idinscrit,Dateop,IsAbsent,VerseCash,VerseTransfert,NumBordero")]*/ PresenceDto valueDto)
        {
            if (ModelState.IsValid)
            {
                //_context.Add(presenceDto);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                MeetPresence presence = valueDto.ToEntity();
                int SavedElts = await _repository.Add(presence);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.SeanceId);
            SetViewDataElements(valueDto);
            return View(valueDto);
        }

        /// <summary>
        /// Affiche le formulaire permettant de payer les engagements d'un membre au cours d'une séance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repartitionAuto"></param>
        /// <returns></returns>
        // GET: Presences/PayerEngagements/5
        public async Task<IActionResult> PayerEngagements(int? id, bool repartitionAuto = true)
        {
            if (id == null)
            {
                //  return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            //var presence = await _context.MeetPresences
            //                             .Include(m => m.Seance.CoreSubdivision)
            //                             .Include(m => m.IdinscritNavigation.MeetAntenne)
            //                             .Include(m => m.IdinscritNavigation.Person)
            //                             .FirstAsync(m => m.PresenceId == id);
            //if (presence == null)
            //{
            //    //return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            //var details = from eng in _context.MeetEngagements.Include(m => m.Rubrique).Include(m => m.Person)
            //              join ins in _context.MeetInscriptions on eng.PersonId equals ins.PersonId
            //              join pers in _context.CorePeople on eng.PersonId equals pers.PersonId
            //              //join rub in _context.MeetRubriques on eng.RubriqueId equals rub.RubriqueId
            //              where ins.Idinscrit == presence.Idinscrit && (eng.ToPay - eng.Cumulverse) > 0
            //              orderby eng.Rubrique.Libelle
            //              select new { eng/*, pers, rub*/ };

            ////var details = _context.MeetEngagements.Include(m => m.Rubrique)
            ////                                .Include(m => m.Person)
            ////                                .ThenInclude(m => m.MeetInscriptions.Where(p => p.Idinscrit == presenceDto.Idinscrit))
            ////                                //.Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
            ////                                //.Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
            ////                                .Where(m => (m.ToPay - m.Cumulverse) > 0).AsNoTracking();
            ////var d1 =  _context.MeetEngagements.Join(_context.MeetInscriptions, e=>e.PersonId, i=>i.PersonId, (e,i)=> new )

            ////           IQueryable <MeetEngagement> details = _context.Database
            ////                                                        .SqlQuery<MeetEngagement>($@"SELECT e.* FROM meet_engagement e 
            ////JOIN meet_inscription i ON (e.person_id = i.person_id AND i.idinscrit = {{presenceDto.Idinscrit}}) 
            ////JOIN core_person p ON (p.person_id = i.person_id) 
            ////JOIN meet_rubrique R ON (R.rubrique_id = e.rubrique_id) WHERE (e.to_pay - e.cumulverse) > 0 ");

            //if (details != null)
            //{
            //    //presenceDto.PayableAmount = details.Sum(m => (m.eng.ToPay - m.eng.Cumulverse));

            //    //if(!repartitionAuto && details.Count() > 0)
            //    //{
            //    //    foreach(var dette in details.ToList())
            //    //    {
            //    //        presenceDto.EntreeCaisses.Add(new EntreeCaisseDto()
            //    //        {
            //    //            EngagementId = dette.eng.EngagementId,
            //    //            Engagement = dette.eng.Adapt<EngagementDto>(),
            //    //            IsOutcome = dette.eng.IsOutcome,
            //    //            Montantverse = 0,
            //    //            PresenceId = presenceDto.PresenceId
            //    //            //, OperationId = 0
            //    //        });
            //    //    }

            //    //}


            //    if (!repartitionAuto && details.Count() > 0)
            //    {
            //        foreach (var dette in details.ToList())
            //        {
            //            presence.MeetEntreeCaisses.Add(new MeetEntreeCaisse()
            //            {
            //                EngagementId = dette.eng.EngagementId,
            //                Engagement = dette.eng,
            //                IsOutcome = dette.eng.IsOutcome,
            //                Montantverse = 0,
            //                PresenceId = presence.PresenceId
            //                //, OperationId = 0
            //            });
            //        }
            //    }
            //}

            var appelResults = await _repository.GetEngagements(id.Value, repartitionAuto);
            var presence = appelResults.Presence;
            if (presence == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            PresenceDto presenceDto = presence.Adapt<PresenceDto>();
            presenceDto.EntreeCaisses = presence.MeetEntreeCaisses.Adapt<List<EntreeCaisseDto>>();

            presenceDto.PayableAmount = appelResults.PayableAmount;// (details == null || details?.Count() == 0) ? 0 : details.Sum(m => (m.eng.ToPay - m.eng.Cumulverse));

           // ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), presenceDto.SeanceId);
            return PartialView("PayerEngagements", presenceDto);
        }


        /// <summary>
        /// Affiche le formulaire permettant de payer les engagements d'un membre au cours d'une séance.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="repartitionAuto"></param>
        /// <returns></returns>
        // GET: Presences/Edit/5
        public async Task<IActionResult> Edit(int? id, bool repartitionAuto = true)
        {
            //if (id == null || _context.MeetPresences == null)
            //{
            //    //  return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            //var presence = await _context.MeetPresences
            //                             .Include(m=>m.Seance.CoreSubdivision)
            //                             .Include(m=>m.IdinscritNavigation.MeetAntenne)
            //                             .Include(m=>m.IdinscritNavigation.Person)
            //                             .FirstAsync(m=>m.PresenceId == id);
            //if (presence == null)
            //{
            //    //return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            //var details = from eng in _context.MeetEngagements.Include(m=>m.Rubrique).Include(m=>m.Person)
            //              join ins in _context.MeetInscriptions on eng.PersonId equals ins.PersonId
            //              join pers in _context.CorePeople on eng.PersonId equals pers.PersonId
            //              //join rub in _context.MeetRubriques on eng.RubriqueId equals rub.RubriqueId
            //              where ins.Idinscrit == presence.Idinscrit && (eng.ToPay - eng.Cumulverse) > 0
            //              orderby eng.Rubrique.Libelle
            //              select new { eng/*, pers, rub*/ };

            ////var details = _context.MeetEngagements.Include(m => m.Rubrique)
            ////                                .Include(m => m.Person)
            ////                                .ThenInclude(m => m.MeetInscriptions.Where(p => p.Idinscrit == presenceDto.Idinscrit))
            ////                                //.Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
            ////                                //.Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
            ////                                .Where(m => (m.ToPay - m.Cumulverse) > 0).AsNoTracking();
            ////var d1 =  _context.MeetEngagements.Join(_context.MeetInscriptions, e=>e.PersonId, i=>i.PersonId, (e,i)=> new )

            ////           IQueryable <MeetEngagement> details = _context.Database
            ////                                                        .SqlQuery<MeetEngagement>($@"SELECT e.* FROM meet_engagement e 
            ////JOIN meet_inscription i ON (e.person_id = i.person_id AND i.idinscrit = {{presenceDto.Idinscrit}}) 
            ////JOIN core_person p ON (p.person_id = i.person_id) 
            ////JOIN meet_rubrique R ON (R.rubrique_id = e.rubrique_id) WHERE (e.to_pay - e.cumulverse) > 0 ");

            //if (details != null)
            //{
            //    //presenceDto.PayableAmount = details.Sum(m => (m.eng.ToPay - m.eng.Cumulverse));

            //    //if(!repartitionAuto && details.Count() > 0)
            //    //{
            //    //    foreach(var dette in details.ToList())
            //    //    {
            //    //        presenceDto.EntreeCaisses.Add(new EntreeCaisseDto()
            //    //        {
            //    //            EngagementId = dette.eng.EngagementId,
            //    //            Engagement = dette.eng.Adapt<EngagementDto>(),
            //    //            IsOutcome = dette.eng.IsOutcome,
            //    //            Montantverse = 0,
            //    //            PresenceId = presenceDto.PresenceId
            //    //            //, OperationId = 0
            //    //        });
            //    //    }

            //    //}


            //    if (!repartitionAuto && details.Count() > 0)
            //    {
            //        foreach (var dette in details.ToList())
            //        {
            //            presence.MeetEntreeCaisses.Add(new MeetEntreeCaisse()
            //            {
            //                EngagementId = dette.eng.EngagementId,
            //                Engagement = dette.eng,
            //                IsOutcome = dette.eng.IsOutcome,
            //                Montantverse = 0,
            //                PresenceId = presence.PresenceId
            //                //, OperationId = 0
            //            });
            //        }                    
            //    }
            //}
            //PresenceDto presenceDto = presence.Adapt<PresenceDto>();
            //presenceDto.EntreeCaisses = presence.MeetEntreeCaisses.Adapt<List<EntreeCaisseDto>>();

            //presenceDto.PayableAmount = (details == null || details?.Count() == 0) ? 0 : details.Sum(m => (m.eng.ToPay - m.eng.Cumulverse));

            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), presenceDto.SeanceId);
            //return PartialView("Edit", presenceDto);
            return PartialView("Edit");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="presenceDto"></param>
        /// <returns></returns>
        // POST: Presences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PresenceDto presenceDto)
        {
            if (id != presenceDto.PresenceId)
            {
                //  return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            if (ModelState.IsValid)
            {
                var presence = presenceDto.Adapt<MeetPresence>(); 
                
                int SavedElts = await _repository.Update(id, presence);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                //int NbSaved = 0;
                //try
                //{
                //    var presence = presenceDto.Adapt<MeetPresence>();
                //    presence.Globalverse = presence.VerseCash + presence.VerseTransfert;

                //    foreach(var elt in presence.MeetEntreeCaisses)
                //    {
                //        var details = _context.MeetEngagements.Find(elt.EngagementId);
                //        if(details != null)
                //        {
                //            details.Cumulverse += elt.Montantverse;
                //            elt.Engagement = details;
                //        }
                //    }

                //    //_context.Attach(presence);
                //     _context.Update(presence);
                //    NbSaved = await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!PresenceExists(presenceDto.PresenceId))
                //    {
                //        //  return NotFound();
                //        return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //if (NbSaved > 0)
                //    //return RedirectToAction(nameof(Index));
                //    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                //else
                //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
           // ViewData["SeanceId"] = new SelectList(_context.Set<SeanceDto>(), "SeanceId", "SeanceId", presenceDto.SeanceId);
            return View(presenceDto);
        }

        // GET: Presences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null || _context.MeetPresences == null)
            //{
            //    // return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            //var presenceDto = await _context.MeetPresences
            //    .Include(m => m.Seance.CoreSubdivision)
            //    .Include(m => m.IdinscritNavigation.MeetAntenne)
            //    .Include(m => m.IdinscritNavigation.Person)
            //    //.ThenInclude(m => m.Person)
            //    .FirstOrDefaultAsync(m => m.PresenceId == id);
            //if (presenceDto == null)
            //{
            //    // return NotFound();
            //    return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            //}

            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Delete", findObj.Adapt<PresenceDto>());
        }

        // POST: Presences/Delete/5
        [HttpPost, ActionName("UndoPaiement")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> UndoConfirmedPaiement(int id)
        {
            int SavedElts = await _repository.UndoPaiement(id);
            if (SavedElts > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);

            //int NbSaved = 0;
            //if (_context.MeetPresences == null)
            //{
            //    return Problem("Entity set 'LabosContext.PresenceDto'  is null.");
            //}

            //var presence = await _context.MeetPresences.FindAsync(id);
            //if (presence != null)
            //{
            //    //removing previous data saved for the same month meeting and for the specified member
            //    if (_context.MeetEntreeCaisses.Any(m => m.PresenceId == presence.PresenceId))
            //    {
            //        foreach (var elt in _context.MeetEntreeCaisses/*.Include(m=>m.Engagement)*/.Where(m => m.PresenceId == presence.PresenceId).ToList())
            //        {
            //            var engage = _context.MeetEngagements.Find(elt.EngagementId);
            //            if (engage is not null)
            //                engage.Cumulverse -= elt.Montantverse;
            //        }
            //        _context.RemoveRange(_context.MeetEntreeCaisses.Where(m => m.PresenceId == presence.PresenceId));

            //        presence.Globalverse = 0;
            //        presence.VerseCash = 0;
            //        presence.VerseTransfert = 0;
            //        presence.NumBordero = string.Empty;
            //    }

            //    _context.Update(presence);

            //    NbSaved = await _context.SaveChangesAsync();
            //    if (NbSaved > 0)
            //        //return RedirectToAction(nameof(Index));
            //        return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            //    else
            //        return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            //}
            ////return NotFound();
            //return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
        }


        // POST: Presences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
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

        //private bool PresenceExists(int id)
        //{
        //  return (_context.MeetPresences?.Any(e => e.PresenceId == id)).GetValueOrDefault();
        //}
    }
}
