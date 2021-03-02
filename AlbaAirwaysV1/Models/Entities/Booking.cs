using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public partial class Booking
    {
        public Booking()
        {
            Passengers = new HashSet<Passenger>();
        }

        public int Id { get; set; }
        public int NoOfAdults { get; set; }
        public int NoOfChildren { get; set; }
        public int NoOfInfants { get; set; }
        public decimal Amount { get; set; }
        public int ConfirmationNo { get; set; }
        public int CustomerId { get; set; }
        public int OutboundFlightId { get; set; }
        public int? InboundFlightId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Flight InboundFlight { get; set; }
        public virtual Flight OutboundFlight { get; set; }
        public virtual ICollection<Passenger> Passengers { get; set; }
    }
}
