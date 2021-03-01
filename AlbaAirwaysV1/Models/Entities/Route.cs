using System;
using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public partial class Route
    {
        public Route()
        {
            Flights = new HashSet<Flight>();
        }

        public int Id { get; set; }
        public string RouteName { get; set; }
        public string AirportFrom { get; set; }
        public string AirportTo { get; set; }

        public virtual ICollection<Flight> Flights { get; set; }
    }
}
