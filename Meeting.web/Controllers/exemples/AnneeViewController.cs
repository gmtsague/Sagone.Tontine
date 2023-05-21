//using AspNetCore;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meeting.web.Controllers.exemples
{
    public class AnneeViewController : Controller
    {
        // GET: AnneeViewController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AnneeViewController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AnneeViewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnneeViewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnneeViewController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AnneeViewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AnneeViewController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AnneeViewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
