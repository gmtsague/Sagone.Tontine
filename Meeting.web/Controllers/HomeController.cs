using Meeting.web.Models;
using Meeting.Web.Views.Shared.Components.SessionHeader;
using MeetingEntities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Mail;
using System.Runtime.CompilerServices;

namespace Meeting.web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly LabosContext _context;

        public HomeController(ILogger<HomeController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            // ViewData["DefaultAnneeId"] = UtilityController.GetSelectListOfAnnees(_context);
            // ViewData["DefaultEtabId"] = UtilityController.GetSelectListOfEtablissements(_context);
            string host = $"{Request.Scheme}://{Request.Host}{Request.PathBase}/";
            TempData["BaseUrl"] = host;

            return View();
           // return ViewComponent(nameof(SessionHeaderVC), new  { /*maxPriority = maxPriority, isDone = isDone*/  });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}