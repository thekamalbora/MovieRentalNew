using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRental.Models;

namespace MovieRental.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

       
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please Enter Movie Name.")]
        public string Name { get; set; }


        [Display(Name = "Genre")]
        [Required(ErrorMessage = "Please Select Genre.")]
        public int? GenreId { get; set; }
        [Display(Name = "Release Date")]

        [Required(ErrorMessage = "Please Enter Release Date.")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please Enter Added Date.")]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "Please Enter Number In Stock")]
        [Range(1, 20, ErrorMessage = "Please Enter Number Between 1-20")]
        public int? NumberInStock { get; set; }
        public string Title
        {

            get
            {
                if (Id != 0)
                    return "Edit Movie";
                return "New Movie";
            }

        }

        public MovieFormViewModel()
        {
            Id= 0;
        }
        public MovieFormViewModel(Movie movies)
        {
            Id = movies.Id;
            Name = movies.Name;
            ReleaseDate = movies.ReleaseDate;
            DateAdded = movies.DateAdded;
            GenreId = movies.GenreId;
            NumberInStock = movies.NumberInStock;

        }
    }
}