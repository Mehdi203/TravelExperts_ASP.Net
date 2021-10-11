using System.Linq;

namespace TravelExpertTeam2.Models
{
    public class PackageQueryOptions : QueryOptions<Package>
    {
        public void SortFilter(PackagesGridBuilder builder)
        {
            //if (builder.IsFilterByBooking)
            //{
            //    Where = b => b.BookingId == builder.CurrentRoute.BookingFilter;
            //}
            if (builder.IsFilterByPrice)
            {
                if (builder.CurrentRoute.PriceFilter == "under7")
                    Where = b => b.PkgBasePrice < 7;
                else if (builder.CurrentRoute.PriceFilter == "7to14")
                    Where = b => b.PkgBasePrice >= 7 && b.PkgBasePrice <= 14;
                else
                    Where = b => b.PkgBasePrice > 14;
            }
            //if (builder.IsFilterByCustomer)
            //{
            //    int id = builder.CurrentRoute.CustomerFilter.ToInt();
            //    if (id > 0)
            //        Where = b => b.PackageCustomers.Any(ba => ba.Customer.CustomerId == id);
            //}

            //if (builder.IsSortByBooking)
            //{
            //    OrderBy = b => b.Booking.BookingNo;
            //}
            if (builder.IsSortByPrice)
            {
                OrderBy = b => b.PkgBasePrice;
            }
            else
            {
                OrderBy = b => b.PkgName;
            }
        }
    }
}
