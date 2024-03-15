using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HOT4.Controllers
{
    public class AppointmentController : Controller
    {



        private AppointmentContext _context;
        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }



        public IActionResult Index(Appointment appointment)
        {


            var customers = _context.Customers.ToList(); // Fetch all customers from the database
            // Create a SelectList object with CustomerId as the value and Username as the text
            ViewBag.Customers = new SelectList(customers, "CustomerId", "Username");



            return View(appointment);
        }



        [HttpPost]
        public IActionResult CreateAppointment(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(appointment);
                _context.SaveChanges();

                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View(appointment);
            }
        }




    }
}
