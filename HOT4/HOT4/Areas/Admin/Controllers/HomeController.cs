using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HOT4.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class HomeController : Controller
    {

        private AppointmentContext _context;
        public HomeController(AppointmentContext context)
        {
            _context = context;
        }



        public IActionResult Index(Appointment appointment)
        {
            var appointments = _context.Appointments.Include(a => a.Customer).OrderBy(a => a.AppointmentDate).ToList();

            ViewBag.Appointments = appointments;

            return View(appointment);
        }
    }
}
