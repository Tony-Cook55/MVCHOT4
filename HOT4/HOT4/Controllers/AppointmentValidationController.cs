using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Controllers
{
    public class AppointmentValidationController : Controller
    {



        private AppointmentContext _context;
        public AppointmentValidationController(AppointmentContext context)
        {
            _context = context;
        }





        public JsonResult CheckAppointmentDate(DateTime AppointmentDate)
        {
            // Check if appointment time has zero minutes
            if (AppointmentDate.Minute != 0)
            {
                return Json("You may only create appointments on the hour. Minutes should be set to 00.");
            }

            // Check if appointment date/time is in the past
            if (AppointmentDate < DateTime.Today)
            {
                return Json("Appointment date cannot be in the past.");
            }

            // Check if appointment date is less than one day ahead
            if (AppointmentDate.Date <= DateTime.Today.Date)
            {
                return Json("Appointment date must be at least one day ahead of todays date.");
            }

            // Checks if the Appointment Date is already in the database and if so throws error
            if (_context.Appointments.Any(c => c.AppointmentDate == AppointmentDate))
            {
                return Json($"An Appointment at {AppointmentDate} is already Scheduled Please Re-Schedule");
            }


            // If all validations pass, return true
            return Json(true);
        }








/*        public JsonResult CheckExistingAppointments(int CustomerId, DateTime AppointmentDate)
        {
            // Gets the Username of the Customer Based in our passed in CustomerId
            Customer customer = _context.Customers.FirstOrDefault(e => e.CustomerId == CustomerId);

            if (_context.Appointments.Any(c => c.AppointmentDate == AppointmentDate)
                &&
                _context.Appointments.Any(c => c.CustomerId == CustomerId)
                )
            {
                return Json($"An Appointment at {AppointmentDate} is already Scheduled Please Re-Schedule");
            }
            else
            {
                return Json(true);
            }
        }*/






        public IActionResult Index()
        {
            return View();
        }
    }
}
