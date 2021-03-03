using System;
using System.Collections;
using System.Collections.Generic;
using AlbaAirwaysV1.Cart;
using Microsoft.Data.SqlClient;

namespace AlbaAirwaysV1.Models
{
    public class SeatDb
    {
        private const int NumberOfSeats = 24;
        private bool[] _seats = new bool[NumberOfSeats];
        private bool[] _existingSeatingLayoutDb = new bool[NumberOfSeats];
        private bool[] _reservedSeats = new bool[NumberOfSeats];
        private static List<bool[]> _arrays = new List<bool[]>();

        public bool[] GetUpdatedSeats(BookingCart bCart, int flightId)
        {
            _existingSeatingLayoutDb = GetExistingSeatsDb(flightId);
            _reservedSeats = GetReservedSeats(bCart);
            try
            {
                _arrays.Add(_existingSeatingLayoutDb);
                _arrays.Add(_reservedSeats);
                _seats = AddBooleanArrays(_arrays);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.WriteLine(existingSeatingLayoutDB.ToArray()); //for debugging
            //Console.WriteLine(reservedSeats.ToArray());//for debugging
            //Console.WriteLine(seats.ToArray());//for debugging

            //foreach (bool value in seats)
            //{
            //    Console.WriteLine(value);
            //}
            return _seats;
        }

        public bool[] GetExistingSeatsDb(int flightId)
        {
            string connectionString = "Server=DESKTOP-M6282RS\\SS2019;Database=AlbaAirwaysDB;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(null, connection);
                try
                {
                    command.CommandText =
                        $"SELECT * FROM seat WHERE Flight_Id={flightId}";
                    command.Prepare();
                    command.ExecuteNonQuery();

                    ArrayList seatNumbers = new ArrayList();

                    //foreach (int seatNumber in seatNumbers)
                    //{
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                seatNumbers.Add(reader.GetValue(0));
                            }
                        }
                        foreach (int seatNumber in seatNumbers)
                        {
                            _existingSeatingLayoutDb[seatNumber] = true;
                        }
                        //}
                    
                } catch (SqlException sqle)
                {
                    Console.WriteLine("Unable to get records: [" + sqle.Errors + "] " + sqle.Message);
                }
                connection.Dispose();
                return _existingSeatingLayoutDb;
            }
        }

        /* NEEDS TO BE LOOKED AT / MADE TO WORK */
        public bool[] GetReservedSeats(BookingCart bCart)
        {

            if (bCart.Equals(bCart.Persons))
            {
                List<int> outboundSeatNumbers = GetOutboundBookedSeats(bCart);
                if (bCart.Persons.Count > 0)
                {//not needed??
                    bool[] outboundReservedSeats = new bool[NumberOfSeats];
                    foreach (int outboundSeatNumber in outboundSeatNumbers)
                    {
                        outboundReservedSeats[outboundSeatNumber] = true;
                    }
                    _reservedSeats = outboundReservedSeats;
                }
            }
            else if (bCart.Equals(bCart.ReturnPersons))
            {
                List<int> returnSeatNumbers = GetReturnBookedSeats(bCart);
                if (bCart.ReturnPersons.Count > 0)
                {//not needed??
                    bool[] returnReservedSeats = new bool[NumberOfSeats];
                    foreach (int returnSeatNumber in returnSeatNumbers)
                    {
                        returnReservedSeats[returnSeatNumber] = true;
                    }
                    _reservedSeats = returnReservedSeats;
                }
            }
            return _reservedSeats;
        }

        public List<int> GetOutboundBookedSeats(BookingCart bCart)
        {
            List<int> outboundSeatNumbers = new List<int>();
            for (int i = 0; i < bCart.Persons.Count; i++)
            {
                if (bCart.Persons[i].GetSeat().SeatNo != null)
                {
                    int outboundSeatNumber = bCart.Persons[i].GetSeat().SeatNo;
                    outboundSeatNumbers.Add(outboundSeatNumber);
                }
            }
            return outboundSeatNumbers;
        }

        public List<int> GetReturnBookedSeats(BookingCart bCart)
        {
            List<int> returnSeatNumbers = new List<int>();
            for (int i = 0; i < bCart.Persons.Count; i++)
            {
                if (bCart.Persons[i].GetSeat().SeatNo != null)
                {
                    int returnSeatNumber = bCart.Persons[i].GetSeat().SeatNo;
                    returnSeatNumbers.Add(returnSeatNumber);
                }
            }
            return returnSeatNumbers;
        }
        public static bool[] AddBooleanArrays(List<bool[]> arraysToBeAdded)
        {
            bool[] result = new bool[24];
            for (int i = 0; i < 24; i++)
            {
                foreach (bool[] b in arraysToBeAdded)
                {
                    if (b[i])
                    {
                        result[i] = true;
                    }
                }
            }
            return result;
        }

        public void SetSeats(bool[] seats)
        {
            this._seats = seats;
        }
    }
}
