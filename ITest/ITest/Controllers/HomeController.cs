using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ITest.Models;

namespace ITest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User != null &&
               this.User.Identity != null &&
               this.User.Identity.IsAuthenticated)
            {
                if (this.User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "Admin", new { area = "Admin" });
                }

                return RedirectToAction("Index", "Home", new { area = "User" });
            }
            
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
