using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace CountryClubAPI.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
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
                return new JsonResult("Error.");
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
                return new JsonResult("Error.");
            }
        }

        [Route("/api/bookings/daily")]
        public IActionResult DailyBookings()
        {
            var dailyBookings = _context.Bookings.Where(e => e.StartTime.Day == DateTime.Now.Day).ToList();

            return new JsonResult(dailyBookings);
        }

        [Route("/api/bookings/weekly")]
        public IActionResult WeeklyBookings()
        {
            var weeklyBookings = new List<Booking>();
            for(int i = 0; i >= 7; i++)
            {
                weeklyBookings.Add(weeklyBookings[DateTime.Now.Day + i]);
            }

            return new JsonResult(weeklyBookings);
        }
    }
}
