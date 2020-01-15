using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PodLabs.Core;
using PodLabs.Core.Classes.Local;
using PodLabs.Core.Classes.View;
using PodLabs.Core.Classes.zKillboard;

namespace PodLabs.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var context = new PodLabsContext(new DbContextOptionsBuilder<PodLabsContext>().UseMySql(Settings.ReadSettings().ConnectionString).Options);
            var results = from killmails in context.Killmails.Include("Victim").Include("Corporation")
                          select new IndexView { CorporationName = killmails.Victim.Corporation.Name };
            return View(results.ToList());
        }
    }
}