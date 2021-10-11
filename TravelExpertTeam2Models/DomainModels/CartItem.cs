using Newtonsoft.Json;

namespace TravelExpertTeam2.Models
{
    public class CartItem
    {
        public PackageDTO Package { get; set; }
        public int Quantity { get; set; }

        [JsonIgnore]
        public decimal Subtotal =>  (Package.PkgBasePrice) * Quantity;
    }
}
