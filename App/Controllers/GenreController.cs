using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace App.Controllers
{
    public class GenreController : Controller
    {
        
        private readonly Model_Container db = new Model_Container();
        // GET: Movie
        ~GenreController() 
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            if (db.Genres == null)
            {
                return View();
            }
            return View(db.Genres);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apartment/Create
        [HttpPost]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(genre);
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var genre = db.Genres
                .SingleOrDefault(a => a.IDGenre == id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return View(genre);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.Genres.Remove(db.Genres.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
