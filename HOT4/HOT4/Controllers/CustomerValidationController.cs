using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Controllers
{
    public class CustomerValidationController : Controller
    {



        private AppointmentContext _context;
        public CustomerValidationController(AppointmentContext context)
        {
            _context = context;
        }



        public JsonResult CheckExistingCustomers(string Username, string PhoneNumber)
        {
            if (_context.Customers.Any(c => c.Username == Username)
                &&
                _context.Customers.Any(c => c.PhoneNumber == PhoneNumber)
                )
            {
                return Json($"Customer {Username} already exists");
            }
            else
            {
                return Json(true);
            }
        }




        public IActionResult Index()
        {
            return View();
        }
    }
}
