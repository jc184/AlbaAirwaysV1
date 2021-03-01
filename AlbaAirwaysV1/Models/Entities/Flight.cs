using System;
using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public partial class Flight
    {
        public Flight()
        {
            BookingInboundFlights = new HashSet<Booking>();
            BookingOutboundFlights = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public DateTime FlightDate { get; set; }
        public int RouteId { get; set; }

        public virtual Route Route { get; set; }
        public virtual ICollection<Booking> BookingInboundFlights { get; set; }
        public virtual ICollection<Booking> BookingOutboundFlights { get; set; }
    }
}
