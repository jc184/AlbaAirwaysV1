using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlbaAirwaysV1.Models.Entities;

namespace AlbaAirwaysV1.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AlbaAirwaysDBContext _context;

        public BookingsController(AlbaAirwaysDBContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var albaAirwaysDBContext = _context.Bookings.Include(b => b.Customer).Include(b => b.InboundFlight).Include(b => b.OutboundFlight);
            return View(await albaAirwaysDBContext.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.InboundFlight)
                .Include(b => b.OutboundFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id");
            ViewData["InboundFlightId"] = new SelectList(_context.Flights, "Id", "Id");
            ViewData["OutboundFlightId"] = new SelectList(_context.Flights, "Id", "Id");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NoOfAdults,NoOfChildren,NoOfInfants,Amount,ConfirmationNo,CustomerId,OutboundFlightId,InboundFlightId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", booking.CustomerId);
            ViewData["InboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.InboundFlightId);
            ViewData["OutboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.OutboundFlightId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", booking.CustomerId);
            ViewData["InboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.InboundFlightId);
            ViewData["OutboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.OutboundFlightId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NoOfAdults,NoOfChildren,NoOfInfants,Amount,ConfirmationNo,CustomerId,OutboundFlightId,InboundFlightId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "Id", "Id", booking.CustomerId);
            ViewData["InboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.InboundFlightId);
            ViewData["OutboundFlightId"] = new SelectList(_context.Flights, "Id", "Id", booking.OutboundFlightId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.InboundFlight)
                .Include(b => b.OutboundFlight)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Id == id);
        }
    }
}
