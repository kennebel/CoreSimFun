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
        private IServiceProvider ServiceProvider{ get; set; }
        private IDbMgr DB { get; set; }

        public HomeController(IServiceProvider serviceProvider, IDbMgr db)
        {
            ServiceProvider = serviceProvider;
            DB = db;
        }

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            model.SimEvents = DB.RecentSimEvents().ToList();
            model.Info = DB.GetSimInfo();

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
