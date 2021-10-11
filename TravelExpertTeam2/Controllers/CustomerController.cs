using Microsoft.AspNetCore.Mvc;
using TravelExpertTeam2.Models;

namespace TravelExpertsTeam2.Controllers
{
    public class CustomerController : Controller
    {
        private Repository<Customer> data { get; set; }
        public CustomerController(TravelExpertsContext ctx) => data = new Repository<Customer>(ctx);

        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(GridDTO vals)
        {
            string defaultSort = nameof(Customer.CustFirstName);
            var builder = new GridBuilder(HttpContext.Session, vals, defaultSort);
            builder.SaveRouteSegments();

            var options = new QueryOptions<Customer> {
                Include = "PackageCustomers.Package",
                PageNumber = builder.CurrentRoute.PageNumber,
                PageSize = builder.CurrentRoute.PageSize,
                OrderByDirection = builder.CurrentRoute.SortDirection
            };
            if (builder.CurrentRoute.SortField.EqualsNoCase(defaultSort))
                options.OrderBy = a => a.CustFirstName;
            else
                options.OrderBy = a => a.CustLastName;

            var vm = new CustomerListViewModel {
                Customers = data.List(options),
                CurrentRoute = builder.CurrentRoute,
                TotalPages = builder.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var customer = data.Get(new QueryOptions<Customer> {
                Include = "PackageCustomers.Package",
                Where = a => a.CustomerId == id
            });
            return View(customer);
        }
    }
}