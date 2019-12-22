using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Awards.Models;
using Awards.Models.ViewModels;

namespace Awards.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext _context;
        public HomeController(ApplicationContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mainPage = new MainPage();
            mainPage.Users = _context.Users.ToList();
            mainPage.Awards = _context.Awards.ToList();
            var usersAwards = _context.UsersAwards.ToList();
            foreach (var item in mainPage.Users)
            {
                item.Awards.Add(new Award { Id = usersAwards.FirstOrDefault(a => a.UserId == item.Id).AwardId});
            }
            for (int i = 0; i < mainPage.Users.Count() - 1; i++)
            {
                foreach (var item in mainPage.Awards)
                {
                    mainPage.Users[i].Awards.FirstOrDefault(a => a.Id == item.Id).Title = item.Title;
                    mainPage.Users[i].Awards.FirstOrDefault(a => a.Id == item.Id).Description = item.Description;
                }               
            }
            return View(mainPage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
