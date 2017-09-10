using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using src_lib;
using src_web.ViewModels;

namespace src_web.Controllers
{
    public class HomeController : Controller
    {
        private IServiceProvider serviceProvider{ get; set; }

        public HomeController(IServiceProvider ServiceProvider)
        {
            serviceProvider = ServiceProvider;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.SimEvents = DbMgr.RecentSimEvents().ToList();
            model.Info = DbMgr.GetSimInfo();

            return View(model);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
