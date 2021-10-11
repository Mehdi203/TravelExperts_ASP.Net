using System.ComponentModel.DataAnnotations;

namespace TravelExpertTeam2.Models
{
    public class PackageCustomer
    {
        [Key]
        public int PackageId { get; set; }
        [Key]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
        public Package Package { get; set; }
    }
}
