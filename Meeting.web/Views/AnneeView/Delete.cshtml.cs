using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;

namespace Meeting.web.Controllers.Settings
{
    public class DeleteModel : PageModel
    {
        private readonly MeetingEntities.Models.LabosContext _context;

        public DeleteModel(MeetingEntities.Models.LabosContext context)
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

            var coreannee = await _context.CoreAnnees.FirstOrDefaultAsync(m => m.AnneeId == id);

            if (coreannee == null)
            {
                return NotFound();
            }
            else 
            {
                CoreAnnee = coreannee;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CoreAnnees == null)
            {
                return NotFound();
            }
            var coreannee = await _context.CoreAnnees.FindAsync(id);

            if (coreannee != null)
            {
                CoreAnnee = coreannee;
                _context.CoreAnnees.Remove(CoreAnnee);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
