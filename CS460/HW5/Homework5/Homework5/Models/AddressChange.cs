using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Homework5.Models
{
    public class AddressChange
    {
        [Required]
        [Display(Name = "Change ID")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "ODL")]
        public int ODL { get; set; }


        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }


        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "New Street Address")]
        public string NewStreetAddress { get; set; }

        [Required]
        [Display(Name = "City")]
        public string NewCity { get; set; }

        [Required]
        [Display(Name = "State")]
        public string NewState { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int NewZipCode { get; set; }

        [Required]
        [Display(Name = "County")]
        public string NewCounty { get; set; }

        [Required]
        [Display(Name = "Date Submitted")]
        public DateTime DateSubmitted { get; set; }
    }
}