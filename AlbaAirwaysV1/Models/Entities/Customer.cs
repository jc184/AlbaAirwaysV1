using System;
using System.Collections.Generic;

#nullable disable

namespace AlbaAirwaysV1.Models.Entities
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string MobileNumber { get; set; }
        public string HomePhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string LoginName { get; set; }
        public string LoginPassword { get; set; }
        public string CardType { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string TownCity { get; set; }
        public string CountyState { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
