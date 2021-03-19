using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStatehantering.Models.ViewModels
{
    public class CompanyCreateVM
    {
        [Display(Name = "Support E-mail")]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Company name")]
        [Required]
        public string CompanyName { get; set; }
    }
}
