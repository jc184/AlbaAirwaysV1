using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlbaAirwaysV1.Cart;
using Microsoft.AspNetCore.Http;
using RestSharp;
using ServiceStack.Host;

namespace AlbaAirwaysV1.Models
{
    public class Utilities : IHttpHandler
    {
        IHttpContextAccessor _httpContextAccessor;
        private SeatDB _seatDb;

        public Utilities(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _seatDb = new SeatDB();
        }

        public JsonObject ProcessRequest(HttpContext ctx)
        {
            //try
            //{
                var seatDb = new SeatDB();
                ctx.Response.ContentType = "application/json;charset=utf-8";

                var json = new JsonObject();
                var array = new JsonArray();
                var member = new JsonObject();

                //HttpSession session = request.getSession();
                //int flightId = (int)session.getAttribute("flightId");
                BookingCart bCart = new BookingCart();
                int flightId = 1;
                //bCart = (BookingCart)session.getAttribute("cart");
                //member.put("arrayData", seatDB.getSeatingLayout(flightId));
                member.Add("arrayData", seatDb.GetUpdatedSeats(bCart, flightId).ToArray());
                array.Add(member);

                json.Add("jsonArray", array.ToString());
                
                return json;
            //}
            //catch (IOException e)
            //{
            //    Console.WriteLine(e.Message);
            //}

        }
    }
}
