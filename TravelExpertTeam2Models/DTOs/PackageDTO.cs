using System;
using System.Collections.Generic;

namespace TravelExpertTeam2.Models
{
    public class PackageDTO
    {

        public int PackageId { get; set; }
        public string PkgName { get; set; }
        public DateTime? PkgStartDate { get; set; }
        public DateTime? PkgEndDate { get; set; }
        public string PkgDesc { get; set; }
        public decimal PkgBasePrice { get; set; }
        public decimal? PkgAgencyCommission { get; set; }

        public Dictionary<int, string> Customers { get; set; }

        public void Load(Package package)
        {
            PackageId = package.PackageId;
            PkgName = package.PkgName;
            PkgStartDate = package.PkgStartDate;
            PkgEndDate = package.PkgEndDate;
            PkgDesc = package.PkgDesc;
            PkgBasePrice = package.PkgBasePrice;
            PkgAgencyCommission = package.PkgAgencyCommission;
            
            //Customers = new Dictionary<int, string>();
            //foreach (PackageCustomer pc in package.PackageCustomers) {
            //    Customers.Add(pc.Customer.CustomerId, pc.Customer.CustLastName);
            //}
        }
    }

}
