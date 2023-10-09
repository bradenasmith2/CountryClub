using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
