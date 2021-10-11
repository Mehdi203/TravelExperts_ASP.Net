using Microsoft.AspNetCore.Mvc;
using TravelExpertTeam2.Models;
using Microsoft.AspNetCore.Authorization;

namespace TravelExpertTeam2.Controllers
{
    //[Authorize]
    public class PackageController : Controller
    {
        private TravelExpertsUnitOfWork data { get; set; }
        public PackageController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        //[Authorize(Roles ="Admin,Customer")]
        public ViewResult List(PackagesGridDTO values)
        {
            var builder = new PackagesGridBuilder(HttpContext.Session, values, 
                defaultSortField: nameof(Package.PkgName));

            var options = new PackageQueryOptions
            {
                //Include = "PackageCustomers.Customer, Booking",
                OrderByDirection = builder.CurrentRoute.SortDirection,
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize
            };
            options.SortFilter(builder);

            var vm = new PackageListViewModel {
                Packages = data.Packages.List(options),
                //Customers = data.Customers.List(new QueryOptions<Customer> {
                //    OrderBy = a => a.CustFirstName }),
                //Bookings = data.Bookings.List(new QueryOptions<Booking> {
                //    OrderBy = g => g.BookingNo }),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Packages.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var package = data.Packages.Get(new QueryOptions<Package> {
                Include = "PackageCustomers.Customer, Booking",
                Where = b => b.PackageId == id
            });
            return View(package);
        }

        [HttpPost]
        public RedirectToActionResult Filter(string[] filter, bool clear = false)
        {
            var builder = new PackagesGridBuilder(HttpContext.Session);

            if (clear) {
                builder.ClearFilterSegments();
            }
            else {
                var customer = data.Customers.Get(filter[0].ToInt());
                builder.LoadFilterSegments(filter, customer);
            }

            builder.SaveRouteSegments();
            return RedirectToAction("List", builder.CurrentRoute);
        }
    }   
}