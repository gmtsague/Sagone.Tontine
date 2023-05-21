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

namespace Meeting.Web.Controllers.Traitements
{
    public class InscriptionsController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<InscriptionsController> _logger;

        public InscriptionsController(ILogger<InscriptionsController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Inscriptions
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Inscription");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            TypeAdapterConfig<MeetInscription, InscriptionDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetInscriptions.Include(m => m.Annee).Include(m => m.MeetAntenne).Include(m => m.Person);
            return View(await labosContext.AsNoTracking().ProjectToType<InscriptionDto>().ToListAsync());
        }

        // GET: InscriptionsByAntenne
        public async Task<IActionResult> InscriptionsByAntenne(int Id)
        {
            ViewData["TitleObj"] = new FormTitle("Inscription");

            //ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            TypeAdapterConfig<MeetInscription, InscriptionDto>.NewConfig().MaxDepth(3);

            var labosContext = _context.MeetInscriptions.Include(m => m.Annee)
                                                        .Include(m => m.MeetAntenne)
                                                        .Include(m => m.Person)
                                                        .Where(m=> (Id > 0) ? m.AntenneId == Id : true).AsNoTracking();
            return PartialView("_PartialGridViewInscriptions", await labosContext.ProjectToType<InscriptionDto>().ToListAsync());
        }

        // GET: Inscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetInscriptions == null)
            {
                return NotFound();
            }

            var meetInscription = await _context.MeetInscriptions
                .Include(m => m.Annee)
                .Include(m => m.MeetAntenne)
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (meetInscription == null)
            {
                return NotFound();
            }

            return PartialView("Details", meetInscription.Adapt<InscriptionDto>());
        }

        // GET: Inscriptions/Create
        public IActionResult Create()
        {
            //ViewData["AnneeId"] = Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0);// UtilityController.GetSelectListOfAnnees(_context);
            //ViewData["EtabId"] = Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0); // UtilityController.GetGlobalSelectedAssociation();
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context);
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
        public async Task<IActionResult> Create([Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites")] InscriptionDto valueDto)
        { /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")]*/
            if (ModelState.IsValid)
            {
                MeetInscription meetInscription = valueDto.ToEntity();
                CorePerson? pers = await _context.CorePeople.FindAsync(meetInscription.PersonId);
                
                meetInscription.Nocni = pers?.Nocni;
                meetInscription.IsActive = true;              
                
                _context.Add(meetInscription);
               int savedEntities = await _context.SaveChangesAsync();
                //  return RedirectToAction(nameof(Index));
                if(savedEntities >= 1)
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            //return FormResult.CreateErrorResult(ModelState.);
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            //ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation()/*valueDto.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            return PartialView("Create", valueDto);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> ChangeStatus(int? id, [FromQuery] string newstatus)
        {
            if (id == null || _context.MeetInscriptions == null)
            {
                return NotFound();
            }

            var meetInscription = await _context.MeetInscriptions.Include(m=>m.Annee).FirstAsync(m=>m.Idinscrit == id);
            if (meetInscription == null)
            {
                return NotFound();
            }
            EtablissementDto? selectedEtab = ViewData["SelectedAssociation"] as EtablissementDto;
            AnneeDto? selectedYear = ViewData["SelectedYear"] as AnneeDto;

            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetInscription.AnneeId);
            //ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            ViewData["Newstatus"] = newstatus;
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /* meetInscription.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, meetInscription.PersonId);
            return PartialView("ChangeStatus", meetInscription.Adapt<InscriptionDto>());
        }

        // POST: Inscriptions/Suspendre/5
        [HttpPost, ActionName("Suspendre")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> SuspendreConfirmed(int id, [Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Datesuspension,IsActive")] InscriptionDto valueDto)
        {
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               // MeetInscription meetInscription = valueDto.ToEntity();

                int savedEntities = 0;
                try
                {
                    var meetInscription = await _context.MeetInscriptions.FindAsync(id);
                    if (meetInscription == null)
                    {
                        return NotFound();
                    }
                    
                    meetInscription.IsActive = false;
                    meetInscription.Datesuspension = valueDto.Datesuspension;

                    _context.Update(meetInscription);
                    savedEntities = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetInscriptionExists(valueDto.Idinscrit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                if (savedEntities >= 1)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            // else
            //   return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            return PartialView("Suspendre", valueDto);
        }


        // POST: Inscriptions/Retablir/5
        [HttpPost, ActionName("Retablir")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> RetablirConfirmed(int id, [Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,IsActive")] InscriptionDto valueDto)
        {
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // MeetInscription meetInscription = valueDto.ToEntity();

                int savedEntities = 0;
                try
                {
                    var meetInscription = await _context.MeetInscriptions.FindAsync(id);
                    if (meetInscription == null)
                    {
                        return NotFound();
                    }

                    meetInscription.IsActive = true;
                    meetInscription.Datesuspension = null;

                    _context.Update(meetInscription);
                    savedEntities = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetInscriptionExists(valueDto.Idinscrit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                if (savedEntities >= 1)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            // else
            //   return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            return PartialView("Suspendre", valueDto);
        }

        // GET: Inscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetInscriptions == null)
            {
                return NotFound();
            }

            var meetInscription = await _context.MeetInscriptions.FindAsync(id);
            if (meetInscription == null)
            {
                return NotFound();
            }
            EtablissementDto? selectedEtab = ViewData["SelectedAssociation"] as EtablissementDto;
            AnneeDto? selectedYear = ViewData["SelectedYear"] as AnneeDto;

            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetInscription.AnneeId);
            //ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /* meetInscription.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, meetInscription.PersonId);
            return PartialView("Edit", meetInscription.Adapt<InscriptionDto>());
        }

        // POST: Inscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites")] InscriptionDto valueDto)
        { /*[Bind("Idinscrit,EtabId,AntenneId,PersonId,AnneeId,Dateinscrit,Datesuspension,IsActive,Nocni,Soldedebut,Soldefin,Tauxcotisation,TotalVerse,Cumuldettes,Cumulpenalites,Endette,ReportNouveau")]*/
            if (id != valueDto.Idinscrit)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MeetInscription meetInscription = valueDto.ToEntity();
                int savedEntities = 0;
                try
                {
                    _context.Update(meetInscription);
                    savedEntities = await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetInscriptionExists(meetInscription.Idinscrit))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                // return RedirectToAction(nameof(Index));
                if (savedEntities >= 1)
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            //ViewData["EtabId"] = UtilityController.GetGlobalSelectedAssociation();
            ViewData["AntenneId"] = UtilityController.GetSelectListOfAntennes(_context, UtilityController.GetGlobalSelectedAssociation() /*valueDto.EtabId*/);
            ViewData["PersonId"] = UtilityController.GetSelectListOfPeople(_context, valueDto.PersonId);
            return PartialView("Edit", valueDto);
        }

        // GET: Inscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetInscriptions == null)
            {
                return NotFound();
            }

            var meetInscription = await _context.MeetInscriptions
                .Include(m => m.Annee)
                .Include(m => m.MeetAntenne)
                .Include(m => m.Person)
                .FirstOrDefaultAsync(m => m.Idinscrit == id);
            if (meetInscription == null)
            {
                return NotFound();
            }

            return PartialView("Delete", meetInscription.Adapt<InscriptionDto>());
        }

        // POST: Inscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetInscriptions == null)
            {
                //return Problem("Entity set 'LabosContext.MeetInscriptions'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var meetInscription = await _context.MeetInscriptions.FindAsync(id);
            if (meetInscription != null)
            {
                _context.MeetInscriptions.Remove(meetInscription);
            }

            int savedEntities = await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            if (savedEntities >= 1)
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        private bool MeetInscriptionExists(int id)
        {
          return (_context.MeetInscriptions?.Any(e => e.Idinscrit == id)).GetValueOrDefault();
        }
    }
}
