using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRental.CustomValidation;
using MovieRental.Models;

namespace MovieRental.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int? ID { get; set; }

        [Required(ErrorMessage = "Please Enter Customer Name")]
        [StringLength(255)]

        public string Name { get; set; }
        public bool IsSubcribedToNewsLetter { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please Select Membership Type")]
        public byte? MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }


        public CustomerFormViewModel()
        {
            ID = 0;
        }
        public CustomerFormViewModel(Customer customer)
        {
            ID = customer.ID;
            Name = customer.Name;
            IsSubcribedToNewsLetter = customer.IsSubcribedToNewsLetter;
            MembershipTypeId = customer.MembershipTypeId;
            BirthDate = customer.BirthDate;
        }
    }

    
}