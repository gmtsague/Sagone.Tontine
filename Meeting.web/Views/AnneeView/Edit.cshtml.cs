using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;

namespace Meeting.web.Controllers.Settings
{
    public class EditModel : PageModel
    {
        private readonly MeetingEntities.Models.LabosContext _context;

        public EditModel(MeetingEntities.Models.LabosContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CoreAnnee CoreAnnee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }

            var coreannee =  await _context.CoreAnnees.FirstOrDefaultAsync(m => m.AnneeId == id);
            if (coreannee == null)
            {
                return NotFound();
            }
            CoreAnnee = coreannee;
           ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId");
           ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId");
           ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(CoreAnnee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoreAnneeExists(CoreAnnee.AnneeId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CoreAnneeExists(int id)
        {
          return (_context.CoreAnnees?.Any(e => e.AnneeId == id)).GetValueOrDefault();
        }
    }
}
