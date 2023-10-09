using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountryClubAPI.Models;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public MembersController(CountryClubContext context)
        {
            _context = context;
        }

        [Route("/api/members/error")]
        public string MemberError()
        {
            return "Error. Please try again";
        }

        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        [Route("/api/members/{id:int}")]
        public IActionResult SingleMember(int id)
        {
            if(id != null)
            {
                var member = _context.Members.Find(id);

                return new JsonResult(member);
            }
            else
            {
                return Redirect("/api/members/error");
            }
        }

        [HttpPost]
        public IActionResult NewMember(Member member)
        {
            if(member != null)
            {
                _context.Members.Add(member);
                _context.SaveChanges();

                return Redirect($"/api/members/{member.Id}");
            }
            else
            {
                return Redirect("/api/members/error");
            }
        }

        [HttpPut]
        [Route("/api/members/{id:int}")]
        public IActionResult UpdateMember(int id, Member newMember)
        {
            if (id != null && newMember != null)
            {
                newMember.Id = id;
                _context.Members.Update(newMember);
                _context.SaveChanges();
                return Redirect($"/api/members/{newMember.Id}");
            }
            else
            {
                return Redirect("/api/members/error");
            }
        }

        [HttpDelete]
        [Route("/api/members/{id:int}")]
        public string DeleteMember(int id)
        {
            if(id != null)
            {
                _context.Members.Remove(_context.Members.Find(id));
                _context.SaveChanges();
                return "Deleted.";
            }
            else
            {
                return "Error. Please try again";
            }
        }

        [Route("/api/members/{memberId:int}bookings")]
        public IActionResult MemberBookings(int memberId)
        {
            var member = _context.Members.Find(memberId);
            var bookings = new List<Booking>();

            foreach (var e in _context.Bookings.Where(e => e.MemberId == memberId).Where(e => e.StartTime.Date.ToString() == "9/24/12"))
            {
                bookings.Add(e);
            }

            return new JsonResult(bookings);
        }
    }
}
