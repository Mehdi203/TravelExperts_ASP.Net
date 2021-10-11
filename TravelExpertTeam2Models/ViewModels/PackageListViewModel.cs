using System.Collections.Generic;

namespace TravelExpertTeam2.Models
{
    public class PackageListViewModel 
    {
        public IEnumerable<Package> Packages { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Booking> Bookings { get; set; }
        public Dictionary<string, string> Prices =>
            new Dictionary<string, string> {
                { "under7", "Under $7" },
                { "7to14", "$7 to $14" },
                { "over14", "Over $14" }
            };
    }
}
