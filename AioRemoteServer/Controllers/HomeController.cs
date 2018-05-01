using System.Diagnostics;
using AioRemoteServer.Hubs;
using Microsoft.AspNetCore.Mvc;
using AioRemoteServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;

namespace AioRemoteServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly WorkersSession workersSession;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeController(WorkersSession session, IHubContext<WorkersHub> workersHubContext, UserManager<ApplicationUser> manager)
        {
            this.workersSession = session;
            this.workersSession.SetHubContext(workersHubContext);
            this.userManager = manager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Debug()
        {
            return View("Dashboard");
        }

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
