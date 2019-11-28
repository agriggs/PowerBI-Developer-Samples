using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.PowerBI.Api.V2;
using Microsoft.PowerBI.Api.V2.Models;
using Microsoft.Rest;
using PowerBIEmbedded_AppOwnsData.Models;
using PowerBIEmbedded_AppOwnsData.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PowerBIEmbedded_AppOwnsData.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmbedService m_embedService;
       
        public HomeController()
        {
            m_embedService = new EmbedService();
        }

        public ActionResult Index()
        {
            var result = new IndexConfig();
            var assembly = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Where(n => n.Name.Equals("Microsoft.PowerBI.Api")).FirstOrDefault();
            if (assembly != null)
            {
                result.DotNETSDK = assembly.Version.ToString(3);
            }
            return View(result);
        }

        public async Task<ActionResult> EmbedReport(string username, string roles)
        {
            string reportId = ConfigurationManager.AppSettings["reportId"];

            var embedResult = await m_embedService.EmbedReport(reportId);
            if (embedResult)
            {
                return View(m_embedService.EmbedConfig);
            }
            else
            {
                return View(m_embedService.EmbedConfig);
            }
        }

        public async Task<ActionResult> EmbedDashboard()
        {
            string dashboardId = ConfigurationManager.AppSettings["dashboardId"];

            var embedResult = await m_embedService.EmbedDashboard(dashboardId);
            if (embedResult)
            {
                return View(m_embedService.EmbedConfig);
            }
            else
            {
                return View(m_embedService.EmbedConfig);
            }
        }

        public async Task<ActionResult> EmbedTile()
        {
            var embedResult = await m_embedService.EmbedTile();
            if (embedResult)
            {
                return View(m_embedService.TileEmbedConfig);
            }
            else
            {
                return View(m_embedService.TileEmbedConfig);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////
        ///
        // Update for the various reports and dashboards here.
        ///
        //////////////////////////////////////////////////////////////////////////////////////

        public async Task<ActionResult> SolarAnalysisReport()
        {
            var id = ConfigurationManager.AppSettings["SolarAnalysisReport"];
            await m_embedService.EmbedReport(id);
            return View(m_embedService.EmbedConfig);
        }

        public async Task<ActionResult> SolarAnalysisOverviewDashboard()
        {
            var id = ConfigurationManager.AppSettings["SolarAnalysisOverviewDashboard"];
            await m_embedService.EmbedDashboard(id);
            return View(m_embedService.EmbedConfig);
        }

        public async Task<ActionResult> SolarAndUsageDashboard()
        {
            var id = ConfigurationManager.AppSettings["SolarAndUsageDashboard"];
            await m_embedService.EmbedDashboard(id);
            return View(m_embedService.EmbedConfig);
        }
    }
}
