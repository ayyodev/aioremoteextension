using AioRemoteServer.Hubs;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;

namespace AioRemoteServer.Pages
{
    public class DashboardModel : PageModel
    {
        private readonly WorkersSession workersSession;
        public DashboardPaged oouiPage { get; private set; }

        public DashboardModel(WorkersSession session, IHubContext<WorkersHub> workersHubContext)
        {
            this.workersSession = session;
            this.workersSession.SetHubContext(workersHubContext);
        }
        public void OnGet()
        {
            this.oouiPage = new DashboardPaged
            {
                BindingContext = new DashboardPageViewModel(this.workersSession, "radufly@gmail.com")
            };
        }
    }
}