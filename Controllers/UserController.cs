using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Awards.Models;
using Microsoft.AspNetCore.Mvc;

namespace Awards.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext _context;
        public UserController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult AddUser()
        {
            return View();
        }
        public IActionResult AddUser(User user)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}