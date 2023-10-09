using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        [Route("/api/bookings/error")]
        public string BookingError()
        {
            return "Error. Please try again";
        }

        [HttpPost]
        [Route("/api/booking")]
        public IActionResult NewBooking(Booking booking)
        {
            if(booking != null) 
            {
                _context.Bookings.Add(booking);
                _context.SaveChanges();
                return Redirect($"/api/bookings/{booking.Id}");
            }
            else
            {
                return Redirect("/api/bookings/error");
            }
        }

        [Route("/api/bookings/{id:int}")]
        public IActionResult SingleBooking(int id)
        {
            if(id != null)
            {
                var booking = _context.Bookings.Find(id);

                return new JsonResult(booking);
            }
            else
            {
                return Redirect("/api/bookings/error");
            }
        }
    }
}
