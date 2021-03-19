using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStatehantering.Models.ViewModels
{
    public class CompanyDisplayVM
    {
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Message { get; set; }
        public string Cookie { get; set; }
    }

}
