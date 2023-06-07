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

namespace Meeting.web.Controllers.Traitements
{
    public class SortieCaissesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<SortieCaissesController> _logger;

        public SortieCaissesController(ILogger<SortieCaissesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
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

            var labosContext = _context.MeetSortieCaisses
                                       .Include(m => m.Rubrique)
                                       .Include(m => m.Seance.CoreSubdivision)
                                       .Include(m => m.IdinscritNavigation)
                                       .ThenInclude(m=>m.Person)
                                       //.Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
                                       .Where(m => m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId)
                                       .Where(m => m.IdinscritNavigation.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
                                       .AsNoTracking().ProjectToType<SortieCaisseDto>();
            return View(await labosContext.ToListAsync());
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

            var labosContext = _context.MeetSortieCaisses
                                       .Include(m => m.Rubrique)
                                       .Include(m => m.Seance.CoreSubdivision)
                                       .Include(m => m.IdinscritNavigation)
                                       .ThenInclude(m => m.Person)
                                       //.Where(m => m.MeetAntenne.EtabId == Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0))
                                       .Where(m => (m.IdinscritNavigation == null || m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId) && m.SeanceId == seanceId)
                                       .Where(m => m.Rubrique.AnneeId == Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0))
                                       .AsNoTracking().ProjectToType<SortieCaisseDto>();
            return PartialView("_PartialOutcomeGridViewBySeance", await labosContext.ToListAsync());
        }

        // GET: SortieCaisses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses
                .Include(m => m.Rubrique)
                .Include(m => m.IdinscritNavigation.Person)
                .Include(m => m.IdinscritNavigation.MeetAntenne)
                .Include(m => m.Seance.CoreSubdivision)
                .FirstOrDefaultAsync(m => m.SortiecaisseId == id);
            if (meetSortieCaisse == null)
            {
                // return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Details", meetSortieCaisse.Adapt<SortieCaisseDto>());
        }

        // GET: SortieCaisses/Create
        public IActionResult Create([FromQuery]int? InscritId, [FromQuery]int? IdSeance)
        {
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0));
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), InscritId ?? 0);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), IdSeance ?? 0);
           
            SortieCaisseDto valueDto = new SortieCaisseDto();
            if (InscritId.HasValue)
                valueDto.Idinscrit = InscritId.Value;
            
            if (IdSeance.HasValue)
                valueDto.SeanceId = IdSeance.Value;

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
                var meetSortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                meetSortieCaisse.RefNo = Guid.NewGuid().ToString().Substring(0, 13);
                _context.Add(meetSortieCaisse);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            //ViewData["EngagementId"] = new SelectList(_context.MeetEngagements, "EngagementId", "EngagementId", valueDto.EngagementId);
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.SeanceId);
            return View("Create",valueDto);
        }

        // GET: SortieCaisses/Edit/5
        public async Task<IActionResult> Edit(int? id, int? Idseance)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses.FindAsync(id);
            if (meetSortieCaisse == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }
            ViewData["ConstraintSeance"] = Idseance ?? 0;
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetSortieCaisse.RubriqueId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)meetSortieCaisse.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), meetSortieCaisse.SeanceId);
            return PartialView("Edit", meetSortieCaisse.Adapt<SortieCaisseDto>());
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
                try
                {
                    var meetSortieCaisse = valueDto.Adapt<MeetSortieCaisse>();
                    _context.Update(meetSortieCaisse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetSortieCaisseExists(valueDto.SortiecaisseId))
                    {
                        //return NotFound();
                        return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            ViewData["RubriqueId"] = UtilityController.GetSelectListOfRubriques(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), valueDto.RubriqueId);
            ViewData["Idinscrit"] = UtilityController.GetSelectListOfInscriptions(_context, Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long) valueDto.Idinscrit);
            ViewData["SeanceId"] = UtilityController.GetSelectListOfSeances(_context, Convert.ToInt64(TempData.Peek("SelectedEtab") ?? 0), Convert.ToInt64(TempData.Peek("SelectedYear") ?? 0), (long)valueDto.SeanceId);
            return PartialView("Edit", valueDto);
        }

        // GET: SortieCaisses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetSortieCaisses == null)
            {
                return NotFound();
            }

            var meetSortieCaisse = await _context.MeetSortieCaisses
                .Include(m => m.Rubrique)
                .Include(m => m.IdinscritNavigation.Person)
                .Include(m => m.IdinscritNavigation.MeetAntenne)
                .Include(m => m.Seance.CoreSubdivision)
                .FirstOrDefaultAsync(m => m.SortiecaisseId == id);
            if (meetSortieCaisse == null)
            {
                //return NotFound();
                return FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);
            }

            return PartialView("Delete", meetSortieCaisse.Adapt<SortieCaisseDto>());
        }

        // POST: SortieCaisses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetSortieCaisses == null)
            {
                return Problem("Entity set 'LabosContext.MeetSortieCaisses'  is null.");
            }
            var meetSortieCaisse = await _context.MeetSortieCaisses.FindAsync(id);
            if (meetSortieCaisse != null)
            {
                _context.MeetSortieCaisses.Remove(meetSortieCaisse);
            }

            int NbSaved = await _context.SaveChangesAsync();
            if (NbSaved > 0)
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            else
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
        }

        private bool MeetSortieCaisseExists(int id)
        {
          return (_context.MeetSortieCaisses?.Any(e => e.SortiecaisseId == id)).GetValueOrDefault();
        }
    }
}
