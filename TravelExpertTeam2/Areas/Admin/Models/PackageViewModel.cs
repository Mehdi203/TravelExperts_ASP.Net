using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TravelExpertTeam2.Models
{

        public class PackageViewModel : IValidatableObject
        {
            public Package Package { get; set; }
            public IEnumerable<Booking> Bookings { get; set; }
            public IEnumerable<Customer> Customers { get; set; }
            public int[] SelectedCustomers { get; set; }

            public IEnumerable<ValidationResult> Validate(ValidationContext ctx)
            {
                if (SelectedCustomers == null)
                {
                    yield return new ValidationResult(
                      "Please select at least one author.",
                      new[] { nameof(SelectedCustomers) });
                }
            }

        }
    }
