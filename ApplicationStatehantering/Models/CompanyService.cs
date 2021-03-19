using ApplicationStatehantering.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStatehantering.Models
{
    public class CompanyService
    {
        public static List<Company> companies = new List<Company>();

        internal void AddCompany(CompanyCreateVM company)
        {
            companies.Add(new Company
            {
                CompanyName = company.CompanyName,
                Email = company.Email
            });
        }
    }
}
