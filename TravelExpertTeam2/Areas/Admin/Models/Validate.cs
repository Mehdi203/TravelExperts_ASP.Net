using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace TravelExpertTeam2.Models
{
    public class Validate
    {
        private const string BookingKey = "validBooking";
        private const string CustomerKey = "validCustomer";
        private const string EmailKey = "validEmail";

        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; }

        public void CheckGenre(string bookingid, Repository<Booking> data)
        {
            Booking entity = data.Get(bookingid);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Genre id {bookingid} is already in the database.";
        }
        public void MarkGenreChecked() => tempData[BookingKey] = true;
        public void ClearGenre() => tempData.Remove(BookingKey);
        public bool IsGenreChecked => tempData.Keys.Contains(BookingKey);

        public void CheckCustomer(string firstName, string lastName, string operation, Repository<Customer> data)
        {
            Customer entity = null; 
            if (Operation.IsAdd(operation)) {
                entity = data.Get(new QueryOptions<Customer> {
                    Where = a => a.CustFirstName == firstName && a.CustLastName == lastName });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" : 
                $"Author {entity.CustLastName} is already in the database.";
        }
        public void MarkAuthorChecked() => tempData[CustomerKey] = true;
        public void ClearAuthor() => tempData.Remove(CustomerKey);
        public bool IsAuthorChecked => tempData.Keys.Contains(CustomerKey);
    }
}
