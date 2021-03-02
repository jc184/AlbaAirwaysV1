using AlbaAirwaysV1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AlbaAirwaysV1.Cart;
using Microsoft.AspNetCore.Http;
using RestSharp;

namespace AlbaAirwaysV1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetSeatingLayout()
        {
            var seatDb = new SeatDB();

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

            return Ok(json);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
