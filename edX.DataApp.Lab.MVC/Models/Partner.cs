using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace edX.DataApp.Lab.MVC.Models
{
    public class Partner
    {
        [Key]
        public int PartnerId { get; set; }

        public string Name { get; set; }

        [Url]
        public string Photo { get; set; }

        [Display(Name = "Is Open")]
        public bool IsOpen { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}