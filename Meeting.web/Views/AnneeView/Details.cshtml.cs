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
    public class DetailsModel : PageModel
    {
        private readonly MeetingEntities.Models.LabosContext _context;

        public DetailsModel(MeetingEntities.Models.LabosContext context)
        {
            _context = context;
        }

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
    }
}
