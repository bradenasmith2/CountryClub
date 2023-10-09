using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    public class BookingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
