using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRental.ViewModels;
using System.Data.Entity.Validation;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            return View(movies);
        }

        public ActionResult MovieForm()
        {
            var geners = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel
            {
                Genres = geners,
            };
            return View("MovieForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InsertUpdateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    
                    Genres=_context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if(movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Id = movie.Id;
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = movie.DateAdded;
            }
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                Console.WriteLine(e);
            }
        
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Edit(int Id)
        {
            var movies = _context.Movies.Single(m => m.Id == Id);
            if (movies == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movies)
            {
                
            
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }
        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==Id);
            return View(movies);
        }
    }
}