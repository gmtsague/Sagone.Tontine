 using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MeetingEntities.Models;

namespace Meeting.web.Controllers.Settings
{
    public class CreateModel : PageModel
    {
        private readonly MeetingEntities.Models.LabosContext _context;

        public CreateModel(MeetingEntities.Models.LabosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["BureauId"] = new SelectList(_context.MeetBureaus, "BureauId", "BureauId");
        ViewData["FrequenceId"] = new SelectList(_context.CoreFrequenceDivisions, "FrequenceId", "FrequenceId");
        ViewData["PreviousYearId"] = new SelectList(_context.CoreAnnees, "AnneeId", "AnneeId");
            return Page();
        }

        [BindProperty]
        public CoreAnnee CoreAnnee { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.CoreAnnees == null || CoreAnnee == null)
            {
                return Page();
            }

            _context.CoreAnnees.Add(CoreAnnee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
