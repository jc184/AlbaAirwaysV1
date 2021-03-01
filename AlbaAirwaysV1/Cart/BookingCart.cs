using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlbaAirwaysV1.Cart
{
    public class BookingCart
    {
        public BookingCart()
        {
            Persons = new List<BookingCartItem>();
            ReturnPersons = new List<BookingCartItem>();
            Total = 0.0;
            AdultDiscount = 1.0;
            ChildDiscount = 0.5;
            InfantDiscount = 0.25;
        }

        public List<BookingCartItem> Persons { get; set; }
        public List<BookingCartItem> ReturnPersons { get; set; }

        public double Total { get; set; }

        public double AdultDiscount { get; set; }

        public double ChildDiscount { get; set; }

        public double InfantDiscount { get; set; }



        public void addItem(BookingCartItem item)
        {
            //If the item already exists in the cart, only the quantity is changed.
            int code = item.getSeat().SeatNo;
            for (int i = 0; i < Persons.Count; i++)
            {
                BookingCartItem lineItem = Persons[i];
                if (lineItem.getSeat().SeatNo == code)
                {
                    return;
                }
            }
            Persons.Add(item);
        }

        public void removeItem(BookingCartItem item)
        {
            int code = item.getSeat().SeatNo;
            for (int i = 0; i < Persons.Count; i++)
            {
                BookingCartItem lineItem = Persons[i];
                if (lineItem.getSeat().SeatNo == code)
                {
                    Persons.RemoveAt(i);
                    return;
                }
            }
        }

        public double getBookingAmount()
        {//Should work 
            Double amount = 0.0;
            Double returnAmount = 0.0;

            foreach (BookingCartItem bcItem in Persons)
            {
                amount += bcItem.getSeatTotal();
            }
            foreach (BookingCartItem returnBcItem in ReturnPersons)
            {
                returnAmount += returnBcItem.getSeatTotal();
            }
            double totalAmount = amount + returnAmount;
            return totalAmount;
        }

    }
}
