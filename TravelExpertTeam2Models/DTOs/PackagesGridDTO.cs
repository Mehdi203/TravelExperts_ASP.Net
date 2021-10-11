using Newtonsoft.Json;

namespace TravelExpertTeam2.Models
{
    public class PackagesGridDTO : GridDTO
    {
        [JsonIgnore]
        public const string DefaultFilter = "all";

        public string Customer { get; set; } = DefaultFilter;
        public string Booking { get; set; } = DefaultFilter;
        public string PkgBasePrice { get; set; } = DefaultFilter;
    }
}
