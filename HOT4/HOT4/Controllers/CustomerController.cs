using HOT4.Models;
using Microsoft.AspNetCore.Mvc;

namespace HOT4.Controllers
{
    public class CustomerController : Controller
    {


        private AppointmentContext _context;
        public CustomerController(AppointmentContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }





        [HttpPost]
        public IActionResult CreateNewCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();

                return RedirectToAction(actionName: "Index", controllerName: "Home");
            }
            else
            {
                return View(customer);
            }
        }







    }
}
