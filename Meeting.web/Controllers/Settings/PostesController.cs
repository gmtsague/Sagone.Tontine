using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting.Web.Dto;
using MeetingEntities.Models;
using Mapster;
using Meeting.web.Controllers;
using FormHelper;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Meeting.Web.Controllers.Settings
{
    public class PostesController : Controller
    {
        private readonly LabosContext _context;

        private readonly ILogger<PostesController> _logger;

        public PostesController(ILogger<PostesController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: Postes
        public async Task<IActionResult> Index()
        {
            ViewData["TitleObj"] = new FormTitle("Poste du bureau");

            var ViewModel = new AppPageViewModel<PosteDto>();
            ViewModel.DataRecords = await _context.MeetPostes.AsQueryable().ProjectToType<PosteDto>().ToListAsync();
            
            return _context.MeetPostes != null ? 
                          View(/*await _context.MeetPostes.AsQueryable().ProjectToType<PosteDto>().ToListAsync()*/ViewModel) :
                           FormResult.CreateErrorResult(UtilityController.RequestedEntityNotFound);/*Problem("Entity set 'LabosContext.PosteDto'  is null."*/;
        }

        // GET: Postes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MeetPostes == null)
            {
                return NotFound();
            }

            var poste = await _context.MeetPostes
                .FirstOrDefaultAsync(m => m.PosteId == id);
            if (poste == null)
            {
                return NotFound(); 
            }

            return PartialView("Details", poste.Adapt<PosteDto>());
        }

        // GET: Postes/Create
        public IActionResult Create()
        {
            return PartialView("Create");
        }

        // POST: Postes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Create([Bind("PosteId,Libelle,Code")] PosteDto posteDto)
        {
            if (ModelState.IsValid)
            {
                var meetPoste = posteDto.ToEntity();
                _context.Add(meetPoste);
                await _context.SaveChangesAsync();
                // var localizedString = _localizer["Hello"];
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            return PartialView("Create", posteDto);
        }

        // GET: Postes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MeetPostes == null)
            {
                return NotFound();
            }

            var poste = await _context.MeetPostes.FindAsync(id);
            if (poste == null)
            {
                return NotFound();
            }
            return PartialView("Edit", poste.Adapt<PosteDto>());
        }

        // POST: Postes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> Edit(int id, [Bind("PosteId,Libelle,Code")] PosteDto posteDto)
        {
            if (id != posteDto.PosteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var meetPoste = posteDto.ToEntity();              
                try
                {
                    _context.Update(meetPoste);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PosteExists(posteDto.PosteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch(Exception  ex)
                {
                   return FormResult.CreateErrorResult(ex.Message);
                }
                //return RedirectToAction(nameof(Index));
                return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
            }
            return PartialView("Edit", posteDto);
        }

        // GET: Postes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MeetPostes == null)
            {
                return NotFound();
            }

            var poste = await _context.MeetPostes
                .FirstOrDefaultAsync(m => m.PosteId == id);
            if (poste == null)
            {
                return NotFound();
            }

            return PartialView("Delete", poste.Adapt<PosteDto>());
        }

        // POST: Postes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [FormValidator]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MeetPostes == null)
            {
                //return Problem("Entity set 'LabosContext.PosteDto'  is null.");
                return FormResult.CreateErrorResult(UtilityController.DeleteOperationFailed);
            }
            var posteDto = await _context.MeetPostes.FindAsync(id);
            if (posteDto != null)
            {
                _context.MeetPostes.Remove(posteDto);
            }
            
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return FormResult.CreateSuccessResult(UtilityController.SuccessOperation, Url.Action(nameof(Index)));
        }

        private bool PosteExists(int id)
        {
          return (_context.MeetPostes?.Any(e => e.PosteId == id)).GetValueOrDefault();
        }
    }
}
