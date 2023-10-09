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

        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        [Route("/api/members/{id:int}")]
        public IActionResult SingleMember(int id)
        {
            var member = _context.Members.Find(id);

            return new JsonResult(member);
        }

        [HttpPost]
        public IActionResult NewMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();

            return Redirect($"/api/members/{member.Id}");
        }

        [HttpPut]
        [Route("/api/members/{id:int}")]
        public IActionResult UpdateMember(int id, Member newMember)
        {
            newMember.Id = id;
            _context.Members.Update(newMember);
            _context.SaveChanges();

            return Redirect($"/api/members/{newMember.Id}");
        }

        [HttpDelete]
        [Route("/api/members/{id:int}")]
        public string DeleteMember(int id)
        {
            if(id != null)
            {
                _context.Members.Remove(_context.Members.Find(id));
                _context.SaveChanges();
            }

            return "Deleted.";
        }
    }
}
