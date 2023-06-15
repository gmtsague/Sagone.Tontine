using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.Web.Dto;
using Mapster;
using FormHelper;
using Meeting.Web.Repository;

namespace Meeting.web.Controllers.Traitements
{
    public class OrdrePassagesController : Controller
    {
        //private readonly LabosContext _context;

        private readonly IOrdrePassageRepository _repository;

        private readonly ILogger<OrdrePassagesController> _logger;

        public OrdrePassagesController(ILogger<OrdrePassagesController> logger, IOrdrePassageRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        // GET: OrdrePassages
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Ordre de passages");

            ViewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            //var labosContext = _context.MeetOrdrePassages
            //                            .Include(m => m.CoreSubdivision)
            //                            .Include(m => m.IdinscritNavigation.MeetAntenne)
            //                            //.ThenInclude(m=>m.Person)
            //                            .Include(p => p.IdinscritNavigation.Person)
            //                            .Where(m => m.IdinscritNavigation.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                            .Where(m => m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            //return View(await labosContext.OrderBy(m=>m.CoreSubdivision.MonthDate).ProjectToType<OrdrePassageDto>().ToListAsync());

            var resultItems = await _repository.GetAll( (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0),
                                                     (int)Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) );
            return View( resultItems.Items.AsQueryable().ProjectToType<OrdrePassageDto>().ToList());
        }

        // GET: OrdrePassages
        public async Task<IActionResult> PassagesByAntenne(int Id)
        {          
            ViewData["TitleObj"] = new FormTitle("Ordre de passages");

            //iewData["AntennesData"] = UtilityController.GetSelectListOfAntennes(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0) /*UtilityController.GetGlobalSelectedAssociation()*/);

            //var labosContext = _context.MeetOrdrePassages.Include(m => m.CoreSubdivision)
            //                                             .Include(m => m.IdinscritNavigation.MeetAntenne)
            //                                             //.ThenInclude(m=>m.MeetAntenne)
            //                                             .Include(p => p.IdinscritNavigation.Person)
            //                                             .Where(m => m.IdinscritNavigation.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                                             .Where(m => (Id <= 0 || m.IdinscritNavigation.AntenneId == Id) && m.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            //return PartialView("_PartialGridViewPassages", await labosContext.OrderBy(m => m.CoreSubdivision.MonthDate).AsNoTracking().ProjectToType<OrdrePassageDto>().ToListAsync());

            var resultItems = await _repository.GetByAntenne(Id, (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0),
                                                     (int)Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0));
            return PartialView("_PartialGridViewPassages", resultItems.Items.AsQueryable().ProjectToType<OrdrePassageDto>().ToList());
        }

        private void SetViewDataElements(OrdrePassageDto? valueDto)
        {
            ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_repository.GetUnitOfWork(), valueDto.AnneeId);
            ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_repository.GetUnitOfWork(), UtilityController.GetGlobalSelectedYear(), valueDto?.DivisionId ?? 0);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.Idinscrit ?? 0);
        }

        // GET: OrdrePassages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            return PartialView("Details", findObj.Adapt<OrdrePassageDto>());
        }

        // GET: OrdrePassages/Create
        public IActionResult Create()
        {
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context);
            //ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear());
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            SetViewDataElements(null);
            var valueDto = new OrdrePassageDto() 
            { 
                AnneeId = (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0) 
            };
            return PartialView("Create", valueDto);
        }

        // POST: OrdrePassages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create(/*[Bind("PassageId,AnneeId,DivisionId,Idinscrit,Montantpercu,Heuredebut,Commentaire")]*/ OrdrePassageDto valueDto)
        {
            if (ModelState.IsValid)
            {
                MeetOrdrePassage OrdrePassage = valueDto.ToEntity();

                int SavedElts = await _repository.Add( OrdrePassage);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            //ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear());
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // GET: OrdrePassages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, meetOrdrePassage.AnneeId);
            //ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear(), meetOrdrePassage.DivisionId);
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)meetOrdrePassage.Idinscrit);
            var valueDto = findObj.Adapt<OrdrePassageDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: OrdrePassages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, /*[Bind("PassageId,AnneeId,DivisionId,Idinscrit,Montantpercu,Heuredebut,Commentaire")]*/ OrdrePassageDto valueDto)
        {
            if (id != valueDto.PassageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                MeetOrdrePassage OrdrePassage = valueDto.ToEntity();

                int SavedElts = await _repository.Update(id, OrdrePassage);
                if (SavedElts > 0)
                    //return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            //ViewData["AnneeId"] = UtilityController.GetSelectListOfAnnees(_context, valueDto.AnneeId);
            //ViewData["DivisionId"] = UtilityController.GetSelectListOfYearSubdivisions(_context, UtilityController.GetGlobalSelectedYear(), valueDto.DivisionId);
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: OrdrePassages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", findObj.Adapt<OrdrePassageDto>());
        }

        // POST: OrdrePassages/Delete/5
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

        //private bool MeetOrdrePassageExists(int id)
        //{
        //  return (_context.MeetOrdrePassages?.Any(e => e.PassageId == id)).GetValueOrDefault();
        //}
    }
}
