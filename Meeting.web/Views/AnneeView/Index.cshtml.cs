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
    public class IndexModel : PageModel
    {
        private readonly MeetingEntities.Models.LabosContext _context;

        public IndexModel(MeetingEntities.Models.LabosContext context)
        {
            _context = context;
        }

        public IList<CoreAnnee> CoreAnnee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CoreAnnees != null)
            {
                CoreAnnee = await _context.CoreAnnees
                .Include(c => c.Bureau)
                .Include(c => c.Frequence)
                .Include(c => c.PreviousYear).ToListAsync();
            }
        }
    }
}
