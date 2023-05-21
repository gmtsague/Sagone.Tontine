using Microsoft.AspNetCore.Mvc;
using MeetingEntities.Models;
using Meeting.web.Controllers;

namespace Meeting.Web.Views.Shared.Components.SessionHeader
{
    public class SessionHeaderVC : ViewComponent
    {
        private readonly LabosContext _context;

        public SessionHeaderVC(LabosContext context) => _context = context;

        public async Task<IViewComponentResult> InvokeAsync(int? selectedYear, int? selectedEtab, int? selectedAntena)
        {
            //var items = await GetItemsAsync(maxPriority, isDone);
            ViewData["DefaultAnneeId"] = UtilityController.GetSelectListOfAnnees(_context, selectedYear ?? 0);
            ViewData["DefaultEtabId"] = UtilityController.GetSelectListOfEtablissements(_context, selectedEtab ?? 0);
            ViewData["DefaultAntenne"] = UtilityController.GetSelectListOfAntennes(_context, selectedEtab ?? 0);
            return View(/*items*/);
        }

        //private Task<List<TodoItem>> GetItemsAsync(int maxPriority, bool isDone)
        //{
        //    return db!.ToDo!.Where(x => x.IsDone == isDone &&
        //                         x.Priority <= maxPriority).ToListAsync();
        //}
    }
}
