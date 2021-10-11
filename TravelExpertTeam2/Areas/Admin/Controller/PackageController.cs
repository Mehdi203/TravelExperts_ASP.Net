using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using TravelExpertTeam2.Models;

namespace TravelExpertTeam2.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PackageController : Controller
    {
        private TravelExpertsUnitOfWork data { get; set; }
        public PackageController(TravelExpertsContext ctx) => data = new TravelExpertsUnitOfWork(ctx);

        public ViewResult Index() {
            var search = new SearchData(TempData);
            search.Clear();

            return View();
        }

        [HttpPost]
        public RedirectToActionResult Search(SearchViewModel vm)
        {
            if (ModelState.IsValid) {
                var search = new SearchData(TempData) {
                    SearchTerm = vm.SearchTerm,
                    Type = vm.Type
                };
                return RedirectToAction("Search");
            }  
            else {
                return RedirectToAction("Index");
            }   
        }

        [HttpGet]
        public ViewResult Search() 
        {
            var search = new SearchData(TempData);

            if (search.HasSearchTerm) {
                var vm = new SearchViewModel {
                    SearchTerm = search.SearchTerm
                };

                var options = new QueryOptions<Package> {
                    Include = "Booking, PackageCustomers.Customer"
                };
                if (search.IsPackage) { 
                    options.Where = b => b.PkgName.Contains(vm.SearchTerm);
                    vm.Header = $"Search results for package name '{vm.SearchTerm}'";
                }
                if (search.IsCustomer) {
                    int index = vm.SearchTerm.LastIndexOf(' ');
                    if (index == -1) {
                        options.Where = b => b.PackageCustomers.Any(
                            ba => ba.Customer.CustFirstName.Contains(vm.SearchTerm) || 
                            ba.Customer.CustLastName.Contains(vm.SearchTerm));
                    }
                    else {
                        string first = vm.SearchTerm.Substring(0, index);
                        string last = vm.SearchTerm.Substring(index + 1); 
                        options.Where = b => b.PackageCustomers.Any(
                            ba => ba.Customer.CustFirstName.Contains(first) && 
                            ba.Customer.CustLastName.Contains(last));
                    }
                    vm.Header = $"Search results for customer '{vm.SearchTerm}'";
                }
                //if (search.IsBooking) {                  
                //    options.Where = b => b.GenreId.Contains(vm.SearchTerm);
                //    vm.Header = $"Search results for genre ID '{vm.SearchTerm}'";
                //}
                vm.Packages = data.Packages.List(options);
                return View("SearchResults", vm);
            }
            else {
                return View("Index");
            }     
        }

        [HttpGet]
        public ViewResult Add(int id) => GetPackage(id, "Add");

        [HttpPost]
        public IActionResult Add(PackageViewModel vm)
        {
            if (ModelState.IsValid) {
                data.LoadNewPackageCustomers(vm.Package, vm.SelectedCustomers);
                data.Packages.Insert(vm.Package);
                data.Save();

                TempData["message"] = $"{vm.Package.PkgName} added to packages.";
                return RedirectToAction("Index");  
            }
            else {
                Load(vm, "Add");
                return View("Package", vm);
            }
        }

        [HttpGet]
        public ViewResult Edit(int id) => GetPackage(id, "Edit");
        
        [HttpPost]
        public IActionResult Edit(PackageViewModel vm)
        {
            if (ModelState.IsValid) {
                data.DeleteCurrentPackageCustomers(vm.Package);
                data.LoadNewPackageCustomers(vm.Package, vm.SelectedCustomers);
                data.Packages.Update(vm.Package);
                data.Save(); 
                
                TempData["message"] = $"{vm.Package.PkgName} updated.";
                return RedirectToAction("Search");  
            }
            else {
                Load(vm, "Edit");
                return View("Package", vm);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id) => GetPackage(id, "Delete");

        [HttpPost]
        public IActionResult Delete(PackageViewModel vm)
        {
            data.Packages.Delete(vm.Package); 
            data.Save();
            TempData["message"] = $"{vm.Package.PkgName} removed from packages.";
            return RedirectToAction("Search");  
        }

        private ViewResult GetPackage(int id, string operation)
        {
            var package = new PackageViewModel();
            Load(package, operation, id);
            return View("Package", package);
        }
        private void Load(PackageViewModel vm, string op, int? id = null)
        {
            if (Operation.IsAdd(op)) { 
                vm.Package = new Package();
            }
            else {
                vm.Package = data.Packages.Get(new QueryOptions<Package>
                {
                    Include = "PackageCustomers.Customer, Booking",
                    Where = b => b.PackageId == (id ?? vm.Package.PackageId)
                });
            }

            vm.SelectedCustomers = vm.Package.PackageCustomers?.Select(
                ba => ba.Customer.CustomerId).ToArray();
            vm.Customers = data.Customers.List(new QueryOptions<Customer> {
                OrderBy = a => a.CustFirstName });
            vm.Bookings = data.Bookings.List(new QueryOptions<Booking> {
                    OrderBy = g => g.BookingId });
        }

    }
}