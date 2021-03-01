using System;
using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public partial class Passenger
    {
        public int Id { get; set; }
        public string PassengerName { get; set; }
        public int BookingId { get; set; }
        public int BaggageItemId { get; set; }
        public int BaggageItemWeightKg { get; set; }
        public int SeatSeatNo { get; set; }
        public int SeatFlightId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual Seat Seat { get; set; }
    }
}
