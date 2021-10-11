
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using TravelExpertTeam2.Models;namespace TravelExpertTeam2.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Package> data { get; set; }
        public HomeController(IRepository<Package> rep) => data = rep;
        //{
        // data = (Repository<Package>)rep;
        //} //private readonly ILogger<HomeController> _logger; //public HomeController(ILogger<HomeController> logger)
        //{
        // _logger = logger;
        //} // GET: PackageController

        public ViewResult Index()
        {
            var q = new QueryOptions<Package>();
            q.OrderBy = p => p.PkgName; var packages = data.List(q);
            return View(packages);
            //return View();
        }

        //[Authorize(Roles = "Admin,Customer")]

        public ViewResult Details(int id)
        {
            var package = data.Get(new QueryOptions<Package>
            {
                Where = p => p.PackageId == id
            });
            ViewBag.CurrDt = System.DateTime.Now;
            ViewBag.OnChg = "var input = document.getElementByID(\"endDt\");input.setAttribute(\"min\", this.value);input.setAttribute(\"value\", this.value);";
            return View(package);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
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

