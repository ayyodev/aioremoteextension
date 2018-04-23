﻿using System.Diagnostics;
using System.Threading.Tasks;
using AioRemoteServer.Hubs;
using Microsoft.AspNetCore.Mvc;
using AioRemoteServer.Models;
using AioRemoteServer.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Ooui.AspNetCore;
using Xamarin.Forms;

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
        public async Task<IActionResult> Dashboard()
        {
            var page = new DashboardPaged
            {
                BindingContext = new DashboardPageViewModel(this.workersSession,
                   (await this.userManager.GetUserAsync(this.HttpContext.User)).UserName)
            };

            return new ElementResult(page.GetOouiElement());
        }

        //public IActionResult Debug()
        //{
        //    var page = new ListViewPage();

        //    return new ElementResult(page.GetOouiElement());
        //}

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