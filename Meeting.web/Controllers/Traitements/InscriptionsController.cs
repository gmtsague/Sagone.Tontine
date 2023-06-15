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
using Meeting.web.Controllers;
using FormHelper;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Routing;
using Meeting.Web.Repository;

namespace Meeting.Web.Controllers.Traitements
{
    public class InscriptionsController : Controller
    {
       // private readonly LabosContext _context;

        private readonly IInscriptionRepository _repository;

        private readonly ILogger<InscriptionsController> _logger;

        public InscriptionsController(ILogger<InscriptionsController> logger, IInscriptionRepository repository)
        {
            _logger = logger;
            // _context = context;
            _repository = repository;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Inscription");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            TypeAdapterConfig<MeetInscription, InscriptionDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetAll( (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), 
                                                        (int)Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) );
            return View(resultItems.Items.AsQueryable().ProjectToType<InscriptionDto>().ToList());

            //var labosContext = _context.MeetInscriptions
            //                            .Include(m => m.MeetAntenne)
            //                            .Include(m => m.Annee)                                        
            //                            .Include(m => m.Person)
            //                            .Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                            .Where(m => m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
            //                            .AsNoTracking();
            //return View(await labosContext.ProjectToType<InscriptionDto>().ToListAsync());
        }

        // GET: InscriptionsByAntenne
        public async Task<IActionResult> InscriptionsByAntenne(int Id)
        {
            ViewData["TitleObj"] = new FormTitle("Inscription");

            //ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            TypeAdapterConfig<MeetInscription, InscriptionDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetByAntenne(Id, (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0),
                                                                 (int)Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) );
            return View(resultItems.Items.AsQueryable().ProjectToType<InscriptionDto>().ToList());

            //var labosContext = _context.MeetInscriptions.Include(m => m.MeetAntenne)
            //                                            .Include(m => m.Annee)                                                        
            //                                            .Include(m => m.Person)
            //                                            .Where(m=> m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                                            .Where(m=> (Id <= 0 || m.AntenneId == Id)&& m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
            //                                            .AsNoTracking();
            //return PartialView("_PartialGridViewInscriptions", await labosContext.ProjectToType<InscriptionDto>().ToListAsync());
        }

        private void SetViewDataElements(InscriptionDto? valueDto)
        {
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_repository.GetUnitOfWork(), UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_repository.GetUnitOfWork(), valueDto?.PersonId ?? 0);
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", findObj.Adapt<InscriptionDto>());
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            //ViewData["AnneeId"] = Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0);// UtilityController.GetSelectListOfAnnees(_context);
            //ViewData["EtabId"] = Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0); // UtilityController.GetGlobalSelectedAssociation();
            SetViewDataElements(null);
            var newObj = new InscriptionDto() 
            { 
                AnneeId = Convert.ToInt32(TempData.Peek("SelectedYear") ?? 0), 
                EtabId = Convert.ToInt32(TempData.Peek("SelectedEtab") ?? 0) 
            };
            return PartialView("Create", newObj);
        }

        // POST: Inscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites")]*/ InscriptionDto valueDto)
        { /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")]*/
            if (ModelState.IsValid)
            {
                MeetInscription meetInscription = valueDto.ToEntity();
                int SavedElts = await _repository.Add(meetInscription);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                // CorePerson? pers = await _context.CorePeople.FindAsync(meetInscription.PersonId);

                // meetInscription.Nocni = pers?.Nocni;
                // meetInscription.IsActive = true;              

                // _context.Add(meetInscription);
                //int savedEntities = await _context.SaveChangesAsync();
                // //  return RedirectToAction(nameof(Index));
                // if(savedEntities >= 1)
                // return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ////return FormResult.CreateErrorResult(ModelState.);
            ////ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ////ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation()/*valueDto.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> ChangeStatus(int? id, [FromQuery] string newstatus)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            EtablissementDto? selectedEtab = ViewData["SelectedAssociation"] as EtablissementDto;
            AnneeDto? selectedYear = ViewData["SelectedYear"] as AnneeDto;

           // //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetInscription.AnneeId);
           // //ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            ViewData["Newstatus"] = newstatus;
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /* meetInscription.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, meetInscription.PersonId);
            var valueDto = findObj.Adapt<InscriptionDto>();
            SetViewDataElements(valueDto);
            return PartialView("ChangeStatus", valueDto);
        }

        // POST: Inscriptions/Suspendre/5
        [HttpPost, ActionName("Suspendre")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SuspendreConfirmed(int id, /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Datesuspension,IsActive")]*/ InscriptionDto valueDto)
        {
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // MeetInscription meetInscription = valueDto.ToEntity();

                int SavedElts = await _repository.ToggleStatus(id, false, valueDto.Datesuspension);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                //int savedEntities = 0;
                //try
                //{
                //    var meetInscription = await _context.MeetInscriptions.FindAsync(id);
                //    if (meetInscription == null)
                //    {
                //        return NotFound();
                //    }

                //    meetInscription.IsActive = false;
                //    meetInscription.Datesuspension = valueDto.Datesuspension;

                //    _context.Update(meetInscription);
                //    savedEntities = await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MeetInscriptionExists(valueDto.Idinscrit))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //// return RedirectToAction(nameof(Index));
                //if (savedEntities >= 1)
                //    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            // else
            //   return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            SetViewDataElements(valueDto);
            return PartialView("Suspendre", valueDto);
        }


        // POST: Inscriptions/Retablir/5
        [HttpPost, ActionName("Retablir")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> RetablirConfirmed(int id, /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,IsActive")]*/ InscriptionDto valueDto)
        {
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // MeetInscription meetInscription = valueDto.ToEntity();
                int SavedElts = await _repository.ToggleStatus(id, true, null);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                //int savedEntities = 0;
                //try
                //{
                //    var meetInscription = await _context.MeetInscriptions.FindAsync(id);
                //    if (meetInscription == null)
                //    {
                //        return NotFound();
                //    }

                //    meetInscription.IsActive = true;
                //    meetInscription.Datesuspension = null;

                //    _context.Update(meetInscription);
                //    savedEntities = await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MeetInscriptionExists(valueDto.Idinscrit))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //// return RedirectToAction(nameof(Index));
                //if (savedEntities >= 1)
                //    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            // else
            //   return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            SetViewDataElements(valueDto);
            return PartialView("Suspendre", valueDto);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            EtablissementDto? selectedEtab = ViewData["SelectedAssociation"] as EtablissementDto;
            AnneeDto? selectedYear = ViewData["SelectedYear"] as AnneeDto;

            ////ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetInscription.AnneeId);
            ////ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /* meetInscription.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, meetInscription.PersonId);
            
            var valueDto = findObj.Adapt<InscriptionDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites")]*/ InscriptionDto valueDto)
        { /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")]*/
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MeetInscription meetInscription = valueDto.ToEntity();

                int SavedElts = await _repository.Update(id, meetInscription);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");

                // int savedEntities = 0;
                //try
                //{
                //    _context.Update(meetInscription);
                //    savedEntities = await _context.SaveChangesAsync();
                //}
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!MeetInscriptionExists(meetInscription.Idinscrit))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                //// return RedirectToAction(nameof(Index));
                //if (savedEntities >= 1)
                //    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ////ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            ////ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            //ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            //ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", findObj.Adapt<InscriptionDto>());
        }

        // POST: Inscriptions/Delete/5
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

        //private bool MeetInscriptionExists(int id)
        //{
        //  return (_context.MeetInscriptions?.Any(e => e.Idinscrit == id)).GetValueOrDefault();
        //}
    }
}
