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
using Microsoft.AspNetCore.Routing;
using Meeting.Web.Repository;

namespace Meeting.web.Controllers.Traitements
{
    public class SortieCaissesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ISortiecaisseRepository _repository;

        private readonly ILogger<SortieCaissesController> _logger;

        public SortieCaissesController(ILogger<SortieCaissesController> logger, ISortiecaisseRepository repository)
        {
            _logger = logger;
            //_context = context;
            _repository = repository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // GET: SortieCaisses
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Sortie de caisse");

            TypeAdapterConfig<MeetSortieCaisse,SortieCaisseDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetAll( (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return View(resultItems.Items.AsQueryable().ProjectToType<SortieCaisseDto>().ToList());

            //var labosContext = _context.MeetSortieCaisses
            //                           .Include(m => m.Rubrique)
            //                           .Include(m => m.Seance.CoreSubdivision)
            //                           .Include(m => m.IdinscritNavigation)
            //                           .ThenInclude(m=>m.Person)
            //                           //.Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                           .Where(m => m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId)
            //                           .Where(m => m.IdinscritNavigation.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
            //                           .AsNoTracking().ProjectToType<SortieCaisseDto>();
            //return View(await labosContext.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seanceId"></param>
        /// <returns></returns>
        // GET: SortieCaisses/GetDataBySeance
        public async Task<IActionResult> GetDataBySeance(int seanceId)
        {
            ViewData["TitleObj"] = new FormTitle("Sortie de caisse");
            ViewData["SeanceId"] = seanceId;

            TypeAdapterConfig<MeetSortieCaisse, SortieCaisseDto>.NewConfig().MaxDepth(3);

            var resultItems = await _repository.GetDataBySeance(seanceId, (int)Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            return PartialView("_PartialOutcomeGridViewBySeance", resultItems.Items.AsQueryable().ProjectToType<SortieCaisseDto>().ToList());

            //var labosContext = _context.MeetSortieCaisses
            //                           .Include(m => m.Rubrique)
            //                           .Include(m => m.Seance.CoreSubdivision)
            //                           .Include(m => m.IdinscritNavigation)
            //                           .ThenInclude(m => m.Person)
            //                           //.Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
            //                           .Where(m => (m.IdinscritNavigation == null || m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId) && m.SeanceId == seanceId)
            //                           .Where(m => m.Rubrique.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
            //                           .AsNoTracking().ProjectToType<SortieCaisseDto>();
            //return PartialView("_PartialOutcomeGridViewBySeance", await labosContext.ToListAsync());
        }

        private void SetViewDataElements(SortieCaisseDto? valueDto)
        {
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.RubriqueId ?? 0);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.Idinscrit ?? 0);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_repository.GetUnitOfWork(), Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto?.SeanceId ?? 0);
        }

        // GET: SortieCaisses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", findObj.Adapt<SortieCaisseDto>());
        }

        // GET: SortieCaisses/Create
        public IActionResult Create([FromQuery]int? InscritId, [FromQuery]int? IdSeance)
        {
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), InscritId ?? 0);
            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), IdSeance ?? 0);

            SortieCaisseDto valueDto = new SortieCaisseDto();
            if (InscritId.HasValue)
                valueDto.Idinscrit = InscritId.Value;
            
            if (IdSeance.HasValue)
                valueDto.SeanceId = IdSeance.Value;

            SetViewDataElements(valueDto);
            return PartialView("Create", valueDto);
        }

        // POST: SortieCaisses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(/*[Bind("SortiecaisseId,Idinscrit,SeanceId,RubriqueId,MontantRoute,ListeMandataires,Dateevts,Montantpercu,Note,IsClosed,Visarestants")]*/ SortieCaisseDto valueDto)
        {
            if (ModelState.IsValid)
            {
                var SortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                int SavedElts = await _repository.Add(SortieCaisse);

                if (SavedElts > 0)
                    // return RedirectToAction(nameof(Index));
                    return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                else
                    return FormResult.CreateErrorResult("Echec on saved entity.");
            }
            ////ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId", valueDto.EngagementId);
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.SeanceId);
            SetViewDataElements(valueDto);
            return View("Create",valueDto);
        }

        // GET: SortieCaisses/Edit/5
        public async Task<IActionResult> Edit(int? id, int? Idseance)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            ViewData["ConstraintSeance"] = Idseance ?? 0;
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetSortieCaisse.RubriqueId);
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)meetSortieCaisse.Idinscrit);
            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetSortieCaisse.SeanceId);
            var valueDto = findObj.Adapt<SortieCaisseDto>();
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // POST: SortieCaisses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, /*[Bind("SortiecaisseId,Idinscrit,SeanceId,RubriqueId,MontantRoute,ListeMandataires,Dateevts,Montantpercu,Note,IsClosed,Visarestants")]*/ SortieCaisseDto valueDto)
        {
            if (id != valueDto.SortiecaisseId)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            if (ModelState.IsValid)
            {
                    var SortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                    int SavedElts = await _repository.Update(id, SortieCaisse);

                    if (SavedElts > 0)
                        // return RedirectToAction(nameof(Index));
                        return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
                    else
                        return FormResult.CreateErrorResult("Echec on saved entity.");
             }
            //ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            //ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long) valueDto.Idinscrit);
            //ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.SeanceId);
            SetViewDataElements(valueDto);
            return PartialView("Edit", valueDto);
        }

        // GET: SortieCaisses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var findObj = await _repository.GetDetails(id);
            if (findObj == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", findObj.Adapt<SortieCaisseDto>());
        }

        // POST: SortieCaisses/Delete/5
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

        //private bool MeetSortieCaisseExists(int id)
        //{
        //  return (_context.MeetSortieCaisses?.Any(e => e.SortiecaisseId == id)).GetValueOrDefault();
        //}
    }
}
