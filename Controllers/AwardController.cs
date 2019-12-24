using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awards.Models;
using Microsoft.AspNetCore.Mvc;

namespace Awards.Controllers
{
    public class AwardController : Controller
    {
        ApplicationContext _context;
        public AwardController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult AddAward()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAward(Award award)
        {
            _context.Awards.Add(award);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}