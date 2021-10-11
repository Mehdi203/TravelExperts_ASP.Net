using Microsoft.AspNetCore.Http;

namespace TravelExpertTeam2.Models
{
    public class PackagesGridBuilder : GridBuilder
    {
        public PackagesGridBuilder(ISession sess) : base(sess) { }

        public PackagesGridBuilder(ISession sess, PackagesGridDTO values, 
            string defaultSortField) : base(sess, values, defaultSortField)
        {
            bool isInitial = values.Booking.IndexOf(FilterPrefix.Booking) == -1;
            routes.CustomerFilter = (isInitial) ? FilterPrefix.Customer + values.Customer : values.Customer;
            routes.BookingFilter = (isInitial) ? FilterPrefix.Booking + values.Booking : values.Booking;
            routes.PriceFilter = (isInitial) ? FilterPrefix.PkgBasePrice + values.PkgBasePrice : values.PkgBasePrice;
        }

        public void LoadFilterSegments(string[] filter, Customer customer)
        {
            if (customer == null) { 
                routes.CustomerFilter = FilterPrefix.Customer + filter[0];
            } else {
                routes.CustomerFilter = FilterPrefix.Customer + filter[0]
                    + "-" + customer.CustLastName.Slug();
            }  
            routes.BookingFilter = FilterPrefix.Booking + filter[1];
            routes.PriceFilter = FilterPrefix.PkgBasePrice + filter[2];
        }

        public void ClearFilterSegments() => routes.ClearFilters();

        string def = PackagesGridDTO.DefaultFilter;   
        public bool IsFilterByCustomer => routes.CustomerFilter != def;
        public bool IsFilterByBooking => routes.BookingFilter != def;
        public bool IsFilterByPrice => routes.PriceFilter != def;

        public bool IsSortByBooking =>
            routes.SortField.EqualsNoCase(nameof(Booking));
        public bool IsSortByPrice =>
            routes.SortField.EqualsNoCase(nameof(Package.PkgBasePrice));
    }
}
