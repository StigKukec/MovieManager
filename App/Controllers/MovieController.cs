using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI.WebControls;
using Microsoft.Ajax.Utilities;

namespace App.Controllers
{
    public class MovieController : Controller
    {

        private readonly Model_Container db = new Model_Container();
        // GET: Movie
        ~MovieController()
        {
            db.Dispose();
        }
        public ActionResult Index()
        {
            if (db.Movies == null)
            {
                return View();
            }
            return View(db.Movies);
        }
        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = db.Movies
                .Include(a => a.UploadedPosters)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
 
        // GET: Movie/Create
        public ActionResult Create()
        {
            IEnumerable<Genre> genres = db.Genres;
            ViewBag.Genres = new SelectList(genres, nameof(Genre.IDGenre), nameof(Genre.Name));

            IEnumerable<Director> directors = db.Directors;
            ViewBag.Directors = new SelectList(directors, nameof(Director.IDDirector), nameof(Director.LastName));

            IEnumerable<Actor> actors = db.Actors;
            ViewBag.Actors = new SelectList(actors, nameof(Actor.IDActor), nameof(Actor.LastName));

            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(Movie movie, IEnumerable<HttpPostedFileBase> files)
        {
            try
            {
                string director = Request.Form["hiddenDirector"];
                string genres = Request.Form["hiddenGenres"];
                string actors = Request.Form["hiddenActors"];

                movie.DirectorIDDirector = int.Parse(director);
                movie.UploadedPosters = new List<UploadedPoster>();
                AddFiles(movie, files);
                db.Movies.Add(movie);

                if (!genres.IsNullOrWhiteSpace())
                {
                    string[] detailedGenres = genres.Split(',');
                    for (int i = 0; i < detailedGenres.Length; i++)
                    {
                        int genreId = int.Parse(detailedGenres[i]);
                        Genre genre = db.Genres.FirstOrDefault(x => x.IDGenre.Equals(genreId));
                        movie.Genres.Add(genre);
                        genre.Movies.Add(movie);
                    }
                }

                if (!actors.IsNullOrWhiteSpace())
                {
                    string[] detailedActors = actors.Split(',');
                    for (int i = 0; i < detailedActors.Length; i++)
                    {
                        int actorId = int.Parse(detailedActors[i]);
                        Actor actor = db.Actors.FirstOrDefault(x => x.IDActor.Equals(actorId));
                        movie.Actors.Add(actor);
                        actor.Movies.Add(movie);
                    }
                }
                db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: Movie/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = db.Movies
                .Include(a => a.UploadedPosters)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IEnumerable<HttpPostedFileBase> files)
        {
            var movie = db.Movies.Find(id);
            if (TryUpdateModel(
                movie,
                "",
                new string[]
                {
                    nameof(Movie.Title),
                    nameof(Movie.Description),
                    nameof(Movie.TotalTime)
                }))
            {
                AddFiles(movie, files);

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        private void AddFiles(Movie movie, IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var picture = new UploadedPoster
                    {
                        ContentType = file.ContentType,
                        Name = file.FileName
                    };
                    using (var reader = new System.IO.BinaryReader(file.InputStream))
                    {
                        picture.Content = reader.ReadBytes(file.ContentLength);
                    }
                    movie.UploadedPosters.Add(picture);
                }
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var movie = db.Movies
                .Include(a => a.UploadedPosters)
                .SingleOrDefault(a => a.IDMovie == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            db.UploadedPosters.RemoveRange(db.UploadedPosters.Where(f => f.MovieIDMovie == id));
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
