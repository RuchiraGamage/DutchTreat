using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.Controllers
{
    public class AppController :Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewBag.Title = "Contacts";
            return View();
        }

        public IActionResult AboutUs()
        {
            ViewBag.Title = "AboutUs";
            return View();
        }
    }
}
