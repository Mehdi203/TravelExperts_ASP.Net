using System.Linq;

namespace TravelExpertTeam2.Models
{
    public class TravelExpertsUnitOfWork : ITravelExpertsUnitOfWork
    {
        private TravelExpertsContext context { get; set; }
        public TravelExpertsUnitOfWork(TravelExpertsContext ctx) => context = ctx;

        private Repository<Package> packageData;
        public Repository<Package> Packages {
            get {
                if (packageData == null)
                    packageData = new Repository<Package>(context);
                return packageData;
            }
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers {
            get {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<PackageCustomer> packagecustomerData;
        public Repository<PackageCustomer> PackageCustomers {
            get {
                if (packagecustomerData == null)
                    packagecustomerData = new Repository<PackageCustomer>(context);
                return packagecustomerData;
            }
        }

        private Repository<Agent> agentData;
        public Repository<Agent> Agents
        {
            get {
                if (agentData == null)
                    agentData = new Repository<Agent>(context);
                return agentData;
            }
        }

        private Repository<Affiliation> affiliationData;
        public Repository<Affiliation> Affiliations
        {
            get
            {
                if (affiliationData == null)
                    affiliationData = new Repository<Affiliation>(context);
                return affiliationData;
            }
        }

        private Repository<Agency> agencyData;
        public Repository<Agency> Agencies
        {
            get
            {
                if (agencyData == null)
                    agencyData = new Repository<Agency>(context);
                return agencyData;
            }
        }

        private Repository<Booking> bookingData;
        public Repository<Booking> Bookings
        {
            get
            {
                if (bookingData == null)
                    bookingData = new Repository<Booking>(context);
                return bookingData;
            }
        }


        private Repository<BookingDetail> bookingdetailData;
        public Repository<BookingDetail> BookingDetails
        {
            get
            {
                if (bookingdetailData == null)
                    bookingdetailData = new Repository<BookingDetail>(context);
                return bookingdetailData;
            }
        }


        private Repository<Class> classData;
        public Repository<Class> Classes
        {
            get
            {
                if (classData == null)
                    classData = new Repository<Class>(context);
                return classData;
            }
        }


        private Repository<CreditCard> creditcardData;
        public Repository<CreditCard> CreditCards
        {
            get
            {
                if (creditcardData == null)
                    creditcardData = new Repository<CreditCard>(context);
                return creditcardData;
            }
        }


        private Repository<CustomersReward> customersrewardData;
        public Repository<CustomersReward> CustomersRewards
        {
            get
            {
                if (customersrewardData == null)
                    customersrewardData = new Repository<CustomersReward>(context);
                return customersrewardData;
            }
        }

        private Repository<Employee> employeeData;
        public Repository<Employee> Employees
        {
            get
            {
                if (employeeData == null)
                    employeeData = new Repository<Employee>(context);
                return employeeData;
            }
        }

        private Repository<Fee> feeData;
        public Repository<Fee> Fees
        {
            get
            {
                if (feeData == null)
                    feeData = new Repository<Fee>(context);
                return feeData;
            }
        }

        private Repository<PackagesProductsSupplier> packagesproductssupplierData;
        public Repository<PackagesProductsSupplier> PackagesProductsSuppliers
        {
            get
            {
                if (packagesproductssupplierData == null)
                    packagesproductssupplierData = new Repository<PackagesProductsSupplier>(context);
                return packagesproductssupplierData;
            }
        }

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<ProductsSupplier> productsupplierData;
        public Repository<ProductsSupplier> ProductsSuppliers
        {
            get
            {
                if (productsupplierData == null)
                    productsupplierData = new Repository<ProductsSupplier>(context);
                return productsupplierData;
            }
        }

        private Repository<Region> regionData;
        public Repository<Region> Regions
        {
            get
            {
                if (regionData == null)
                    regionData = new Repository<Region>(context);
                return regionData;
            }
        }

        private Repository<Reward> rewardData;
        public Repository<Reward> Rewards
        {
            get
            {
                if (rewardData == null)
                    rewardData = new Repository<Reward>(context);
                return rewardData;
            }
        }

        private Repository<Supplier> supplierData;
        public Repository<Supplier> Suppliers
        {
            get
            {
                if (supplierData == null)
                    supplierData = new Repository<Supplier>(context);
                return supplierData;
            }
        }

        private Repository<SupplierContact> suppliercontactData;
        public Repository<SupplierContact> SupplierContacts
        {
            get
            {
                if (suppliercontactData == null)
                    suppliercontactData = new Repository<SupplierContact>(context);
                return suppliercontactData;
            }
        }

        private Repository<TripType> triptypeData;
        public Repository<TripType> TripTypes
        {
            get
            {
                if (triptypeData == null)
                    triptypeData = new Repository<TripType>(context);
                return triptypeData;
            }
        }


        public void DeleteCurrentPackageCustomers(Package package)
        {
            var currentCustomers = PackageCustomers.List(new QueryOptions<PackageCustomer> {
                Where = pa => pa.PackageId == package.PackageId
            });
            foreach (PackageCustomer pa in currentCustomers) {
                PackageCustomers.Delete(pa);
            }
        }

        public void LoadNewPackageCustomers(Package package, int[] customerid)
        {
            package.PackageCustomers = customerid.Select(i =>
                new PackageCustomer { Package = package, CustomerId = i })
                .ToList();
        }

        public void Save() => context.SaveChanges();
    }
}