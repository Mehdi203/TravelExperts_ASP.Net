using System.Collections.Generic;

namespace TravelExpertTeam2.Models
{
    public class CustomerListViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
    }
}
