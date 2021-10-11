
namespace TravelExpertTeam2.Models
{
    public interface ITravelExpertsUnitOfWork
    {
        Repository<Package> Packages { get; }
        Repository<Customer> Customers { get; }
        Repository<PackageCustomer> PackageCustomers { get; }
        Repository<Agent> Agents { get; }
        Repository<Affiliation> Affiliations { get; }
        Repository<Agency> Agencies { get; }
        Repository<Booking> Bookings { get; }
        Repository<BookingDetail> BookingDetails { get; }
        Repository<Class> Classes { get; }
        Repository<CreditCard> CreditCards { get; }
        Repository<CustomersReward> CustomersRewards { get; }
        Repository<Employee> Employees { get; }
        Repository<Fee> Fees { get; }
        Repository<PackagesProductsSupplier> PackagesProductsSuppliers { get; }
        Repository<Product> Products { get; }
        Repository<ProductsSupplier> ProductsSuppliers { get; }
        Repository<Region> Regions { get; }
        Repository<Reward> Rewards { get; }
        Repository<Supplier> Suppliers { get; }
        Repository<SupplierContact> SupplierContacts { get; }
        Repository<TripType> TripTypes { get; }


        void DeleteCurrentPackageCustomers(Package package);
        void LoadNewPackageCustomers(Package package, int[] customerid);
        void Save();
    }
}
