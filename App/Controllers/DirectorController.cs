using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace App.Controllers
{
    public class DirectorController : Controller
    {
        
        private readonly Model_Container db = new Model_Container();
        // GET: Movie
        ~DirectorController() 
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            if (db.Directors == null)
            {
                return View();
            }
            return View(db.Directors);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartment/Create
        [HttpPost]
        public ActionResult Create(Director director)
        {
            if (ModelState.IsValid)
            {
                db.Directors.Add(director);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(director);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var director = db.Directors
                .SingleOrDefault(a => a.IDDirector == id);
            if (director == null)
            {
                return HttpNotFound();
            }
            return View(director);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Directors.Remove(db.Directors.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
