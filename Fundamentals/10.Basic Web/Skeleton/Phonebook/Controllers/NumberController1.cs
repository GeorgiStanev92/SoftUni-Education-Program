using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phonebook.Controllers
{
    public class NumberController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Generator(int id)
        {
            return View(id);
        }

        [HttpPost]
        public IActionResult NumGenerator(int num)
        {
            return View(nameof(Generator), num);
        }
    }
}
