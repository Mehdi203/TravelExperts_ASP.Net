using System;
using System.Collections.Generic;
using System.Linq;

namespace TravelExpertTeam2.Models
{
    public static class FilterPrefix
    {
        public const string Booking = "booking-";
        public const string PkgBasePrice = "pkgbaseprice-";
        public const string Customer = "customer-";
    }

    public class RouteDictionary : Dictionary<string, string>
    {
        public int PageNumber {
            get => Get(nameof(GridDTO.PageNumber)).ToInt();
            set => this[nameof(GridDTO.PageNumber)] = value.ToString();
        }

        public int PageSize {
            get => Get(nameof(GridDTO.PageSize)).ToInt();
            set => this[nameof(GridDTO.PageSize)] = value.ToString();
        }

        public string SortField {
            get => Get(nameof(GridDTO.SortField));
            set => this[nameof(GridDTO.SortField)] = value;
        }

        public string SortDirection {
            get => Get(nameof(GridDTO.SortDirection));
            set => this[nameof(GridDTO.SortDirection)] = value;
        }

        public void SetSortAndDirection(string fieldName, RouteDictionary current) {
            this[nameof(GridDTO.SortField)] = fieldName;

            if (current.SortField.EqualsNoCase(fieldName) && 
                current.SortDirection == "asc")
                this[nameof(GridDTO.SortDirection)] = "desc";
            else
                this[nameof(GridDTO.SortDirection)] = "asc";
        }

        public string BookingFilter {
            get => Get(nameof(PackagesGridDTO.Booking))?.Replace(FilterPrefix.Booking, "");
            set => this[nameof(PackagesGridDTO.Booking)] = value;
        }

        public string PriceFilter {
            get => Get(nameof(PackagesGridDTO.PkgBasePrice))?.Replace(FilterPrefix.PkgBasePrice, "");
            set => this[nameof(PackagesGridDTO.PkgBasePrice)] = value;
        }

        public string CustomerFilter {
            get
            {
                string s = Get(nameof(PackagesGridDTO.Customer))?.Replace(FilterPrefix.Customer, "");
                int index = s?.IndexOf('-') ?? -1;
                return (index == -1) ? s : s.Substring(0, index);
            }
            set => this[nameof(PackagesGridDTO.Customer)] = value;
        }

        public void ClearFilters() =>
            BookingFilter = PriceFilter = CustomerFilter = PackagesGridDTO.DefaultFilter;

        private string Get(string key) => Keys.Contains(key) ? this[key] : null;

        public RouteDictionary Clone()
        {
            var clone = new RouteDictionary();
            foreach (var key in Keys) {
                clone.Add(key, this[key]);
            }
            return clone;
        }
    }
}
