using HOT4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HOT4.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class AppointmentController : Controller
    {

        private AppointmentContext _context;
        public AppointmentController(AppointmentContext context)
        {
            _context = context;
        }



        // ------ EDITING A APPOINTMENT ------ \\
        [HttpGet]
        public IActionResult EditAppointment(int id)
        {

            var customers = _context.Customers.ToList(); // Fetch all customers from the database
            // Create a SelectList object with CustomerId as the value and Username as the text
            ViewBag.Customers = new SelectList(customers, "CustomerId", "Username");

            //LINQ Query to find the Appointment with the given id - PK Search
            var appointment = _context.Appointments.Find(id);


            return View(appointment); // sends the appointment to the edit page to auto fill the info
        }





        [HttpPost]
        public IActionResult Edit(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Update(appointment);

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(appointment);
            }
        }

        // ------ EDITING A APPOINTMENT ------ \\








        // ------------------ DELETING APPOINTMENT ------------------ \\
        [HttpGet]
        public IActionResult DeleteAppointment(int AppointmentId)
        {
            var appointment = _context.Appointments.Find(AppointmentId);
            if (appointment != null)
            {
                return View(appointment);
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult DeleteAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                _context.SaveChanges();
            }
            return RedirectToAction("Index", "Home");
        }
        // ------------------ DELETING APPOINTMENT ------------------ \\






    }
}
