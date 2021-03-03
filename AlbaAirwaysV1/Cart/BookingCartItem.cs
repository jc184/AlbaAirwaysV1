using System;
using AlbaAirwaysV1.Models;
using AlbaAirwaysV1.Models.Entities;

namespace AlbaAirwaysV1.Cart
{
    public class BookingCartItem
    {
        private Seat _seat;
        private PassengerEnum _seatOwner;

        public BookingCartItem()
        {
        }

        public BookingCartItem(Seat seat)
        {
            this._seat = seat;
        }

        public BookingCartItem(Seat seat, PassengerEnum seatOwner)
        {
            this._seat = seat;
            this._seatOwner = seatOwner;
        }

        public PassengerEnum PassengerEnum { get; set; }
        

        public Seat GetSeat()
        {
            return _seat;
        }

        public Double GetSeatTotal()
        {
            Double amount = 0.0;
            switch (_seatOwner)
                {
                    case PassengerEnum.Adult:
                        amount = (double)_seat.SeatPrice;
                        break;
                    case PassengerEnum.Child:
                        amount = (double)_seat.SeatPrice * (1 - 0.5);
                        break;
                    case PassengerEnum.Infant:
                        amount = (double)_seat.SeatPrice * (1 - 0.75);
                        break;
                }
            return amount;
        }

        //public String getTotalCurrencyFormat()
        //{
        //    NumberFormat currency = NumberFormat.getCurrencyInstance();
        //    return currency.format(this.getSeatTotal().doubleValue());
        //}

        public void SetSeat(Seat seat)
        {
            this._seat = seat;
        }
    }
}
