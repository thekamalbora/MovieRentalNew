using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieRental.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Enter Movie Name.")]
        public string  Name { get; set; }
        public Genre Genre { get; set; }

        [Display (Name= "Genre")]
        [Required(ErrorMessage = "Please Select Genre.")]
        public int GenreId { get; set; }
        [Display(Name = "Release Date")]

        [Required(ErrorMessage = "Please Enter Release Date.")]
        public DateTime ReleaseDate { get; set; }

        [Required(ErrorMessage = "Please Enter Added Date.")]
        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "Please Enter Number In Stock")]
        [Range(1,20,ErrorMessage = "Please Enter Number Between 1-20")]
        public int NumberInStock { get; set; }
    }
}