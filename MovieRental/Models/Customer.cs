using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MovieRental.CustomValidation;

namespace MovieRental.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Customer Name")]
        [StringLength(255)]
        
        public string Name { get; set; }
        public bool IsSubcribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        [Required(ErrorMessage = "Please Select Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name="Date Of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
    }
}