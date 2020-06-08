using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult Details(int Id)
        {
            var movies = _context.Movies.Include(m => m.Genre).SingleOrDefault(m=>m.Id==Id);
            return View(movies);
        }
    }
}