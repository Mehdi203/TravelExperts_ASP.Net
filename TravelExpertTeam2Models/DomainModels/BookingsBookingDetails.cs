using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertTeam2.Models;

namespace TravelExpertTeam2Models.DomainModels
{
    class BookingsBookingDetails
    {
        public int BookingId { get; set; }
        public int BookingDetailId { get; set; }

        public BookingDetail BookingDetail { get; set;}
        public Booking Booking { get; set;}
    }
}
