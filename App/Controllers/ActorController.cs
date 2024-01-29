using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace App.Controllers
{
    public class ActorController : Controller
    {
        
        private readonly Model_Container db = new Model_Container();
        // GET: Movie
        ~ActorController() 
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            if (db.Actors == null)
            {
                return View();
            }
            return View(db.Actors);
        }
        
        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartment/Create
        [HttpPost]
        public ActionResult Create(Actor actor)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Add(actor);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }
 
        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var actor = db.Actors
                .SingleOrDefault(a => a.IDActor == id);
            if (actor == null)
            {
                return HttpNotFound();
            }
            return View(actor);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
