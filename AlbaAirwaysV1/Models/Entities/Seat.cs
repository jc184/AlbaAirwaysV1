using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public class Seat
    {
        public Seat()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int SeatNo { get; set; }
        public int FlightId { get; set; }
        public int BookingId { get; set; }
        public decimal SeatPrice { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
