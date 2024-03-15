using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{
    public class Customer
    {


        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Please Enter a Username")]
        [Remote(action: "CheckExistingCustomers", controller: "CustomerValidation", AdditionalFields = "PhoneNumber")]
        public string Username { get; set; }



        [Required(ErrorMessage = "Please Enter a Phone Number")]
        [Display(Name = "Phone Number")]
        // Valid inputs:   314-123-1241    314.123.1241    (314)123-1241    3141231241
        [RegularExpression(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$", ErrorMessage = "Invalid Phone Number")]
        [Remote(action: "CheckExistingCustomers", controller: "CustomerValidation", AdditionalFields = "Username")]
        public string PhoneNumber { get; set; }


    }
}
