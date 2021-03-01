using Microsoft.AspNetCore.Mvc;
using System;
using AlbaAirwaysV1.Cart;
using AlbaAirwaysV1.Models;
using AlbaAirwaysV1.Models.Entities;
using Microsoft.AspNetCore.Http;

namespace AlbaAirwaysV1.Controllers
{
    public class SeatingController : ControllerBase
    {
        private Utilities _utilities;
        private SeatDB seatDB;
        private int personCount;
        
        public SeatingController(Utilities utilities)
        {
            _utilities = utilities;
            seatDB = new SeatDB();
            personCount = 0;
        }

        public bool[] SeatingLayout = new bool[24];

        public IActionResult ChooseSeat(int seatNumber, int flightId)
        {
            var url = "";

            String msg = "";
            BookingCart bCart = new BookingCart();
            

            if (personCount == 0)
            {
                if (seatDB.GetUpdatedSeats(bCart, flightId)[seatNumber] == false)
                {
                    Seat seat = new Seat();
                    seat = reserveSeat(seatNumber, flightId);
                    return Ok(seatDB.GetUpdatedSeats(bCart, flightId));
                }
                else 
                {
                    msg = "This seat is already booked. Please choose another seat.";
                }
            }
            else
            {
                msg = "You have already booked your seat for this passenger.";
                
            }
            SeatingLayout = seatDB.GetUpdatedSeats(bCart, flightId);
            return Ok(SeatingLayout);
        }

        public Seat reserveSeat(int seatNumber, int flightId)
        {
            BookingCart bCart = new BookingCart();

            Seat seat = new Seat() {FlightId = flightId, SeatNo = seatNumber};
            bool[] seats = seatDB.GetReservedSeats(bCart);
            seats[seatNumber] = true;
            seatDB.setSeats(seats);
            return seat;
    }

 
        public IActionResult ProcessSeatChoice(string submit)
        {
            
            int seatNumber = 0;
            int flightId = 1;
            if (!string.IsNullOrEmpty(submit) && submit.Length > 0)
            {
                switch (submit)
                {
                    case "seat01":
                        seatNumber = 0;
                        break;
                    case "seat02":
                        seatNumber = 1;
                        break;
                    case "seat03":
                        seatNumber = 2;
                        break;
                    case "seat04":
                        seatNumber = 3;
                        break;
                    case "seat05":
                        seatNumber = 4;
                        break;
                    case "seat06":
                        seatNumber = 5;
                        break;
                    case "seat07":
                        seatNumber = 6;
                        break;
                    case "seat08":
                        seatNumber = 7;
                        break;
                    case "seat09":
                        seatNumber = 8;
                        break;
                    case "seat10":
                        seatNumber = 9;
                        break;
                    case "seat11":
                        seatNumber = 10;
                        break;
                    case "seat12":
                        seatNumber = 11;
                        break;
                    case "seat13":
                        seatNumber = 12;
                        break;
                    case "seat14":
                        seatNumber = 13;
                        break;
                    case "seat15":
                        seatNumber = 14;
                        break;
                    case "seat16":
                        seatNumber = 15;
                        break;
                    case "seat17":
                        seatNumber = 16;
                        break;
                    case "seat18":
                        seatNumber = 17;
                        break;
                    case "seat19":
                        seatNumber = 18;
                        break;
                    case "seat20":
                        seatNumber = 19;
                        break;
                    case "seat21":
                        seatNumber = 20;
                        break;
                    case "seat22":
                        seatNumber = 21;
                        break;
                    case "seat23":
                        seatNumber = 22;
                        break;
                    case "seat24":
                        seatNumber = 23;
                        break;
                }
                personCount++;
                return RedirectToAction("ChooseSeat", "Seating",new { seatNumber, flightId, id = 99 });
            }
            return Ok();
        }



        //public void ProcessRequest(HttpContext ctx)
        //{
        //    var json = new JSONResponse()
        //    {
        //        Success = ctx.Request.QueryString["name"] != null,
        //        Name = ctx.Request.QueryString["name"]
        //    };

        //    ctx.Response.ContentType = "application/json";
        //    ctx.Response.Write(JsonConvert.SerializeObject(json));
        //}

    }
}
