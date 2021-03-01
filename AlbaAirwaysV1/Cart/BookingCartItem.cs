using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlbaAirwaysV1.Models;
using AlbaAirwaysV1.Models.Entities;

namespace AlbaAirwaysV1.Cart
{
    public class BookingCartItem
    {
        private Seat seat;
        private PassengerEnum seatOwner;

        public BookingCartItem()
        {
        }

        public BookingCartItem(Seat seat)
        {
            this.seat = seat;
        }

        public BookingCartItem(Seat seat, PassengerEnum seatOwner)
        {
            this.seat = seat;
            this.seatOwner = seatOwner;
        }

        public PassengerEnum PassengerEnum { get; set; }
        

        public Seat getSeat()
        {
            return seat;
        }

        public Double getSeatTotal()
        {
            Double amount = 0.0;
            switch (seatOwner)
                {
                    case PassengerEnum.Adult:
                        amount = (double)seat.SeatPrice;
                        break;
                    case PassengerEnum.Child:
                        amount = (double)seat.SeatPrice * (1 - 0.5);
                        break;
                    case PassengerEnum.Infant:
                        amount = (double)seat.SeatPrice * (1 - 0.75);
                        break;
                }
            return amount;
        }

        //public String getTotalCurrencyFormat()
        //{
        //    NumberFormat currency = NumberFormat.getCurrencyInstance();
        //    return currency.format(this.getSeatTotal().doubleValue());
        //}

        public void setSeat(Seat seat)
        {
            this.seat = seat;
        }
    }
}
