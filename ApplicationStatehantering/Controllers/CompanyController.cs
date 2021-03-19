using ApplicationStatehantering.Models;
using ApplicationStatehantering.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationStatehantering.Controllers
{
    public class CompanyController : Controller
    {
        CompanyService service = new CompanyService();

        IMemoryCache cache;

        public CompanyController(IMemoryCache cache)
        {
            this.cache = cache;
        }

        [Route("")]
        [Route("Settings/Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Route("")]
        [Route("Settings/Create")]
        [HttpPost]
        public IActionResult Create(CompanyCreateVM company)
        {
            service.AddCompany(company);

            cache.Set("supportEmail", company.Email);
            HttpContext.Session.SetString("CompanyName", company.CompanyName);

            Response.Cookies.Append("VisitDate", DateTime.Now.ToString(),
                new CookieOptions { Expires = DateTime.Now.AddDays(7) });

            TempData["Message"] = "Dina värden har sparats!";
            return RedirectToAction(nameof(Display));
        }

        [Route("settings/display")]
        public IActionResult Display()
        {
            var viewModel = new CompanyDisplayVM
            {
                Email = cache.Get<string>("supportEmail"),
                Message = (string)TempData["Message"],
                CompanyName = HttpContext.Session.GetString("CompanyName"),
                Cookie = Request.Cookies["visitDate"]
            };

            return View(viewModel);
        }
    }
}
