using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace CountryClubAPI.Controllers
{
    public class BookingsController : Controller
    {
        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        [Route("/api/bookings")]
        public IActionResult AllBookings()
        {
            return new JsonResult(_context.Bookings);
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
                Console.WriteLine(booking.StartTime.ToShortDateString());
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
            var day = DateTime.Now.Day;

            foreach(var e in _context.Bookings)
            {
                if(e.StartTime.Day == day)
                {
                    weeklyBookings.Add(e);
                }
            }

            var noDuplicates = weeklyBookings.Distinct().ToList();
            return new JsonResult(noDuplicates);
        }

        [Route("/api/members/bookings")]
        public IActionResult MemberBookings()
        {
            var bookings = new List<Booking>();
            var names = new List<string>();

            foreach (var e in _context.Bookings.Include(e => e.Member))
            {
                if(e.StartTime.ToShortDateString() == "9/24/2012")
                {
                    bookings.Add(e);

                    foreach(var e2 in bookings)
                    {
                        var member = e2.Member;

                        names.Add($"{member.LastName}, {member.FirstName}");
                    }
                }
            }
            var noDuplicates = names.Distinct().ToList();

            return new JsonResult(noDuplicates);
        }
    }
}
