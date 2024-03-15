using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HOT4.Models
{
    public class Appointment
    {

        public int AppointmentId { get; set; }



        [Required(ErrorMessage = "Please Add The Appointment's Date")]
        [Remote(action: "CheckAppointmentDate", controller: "AppointmentValidation")]
        public DateTime AppointmentDate { get; set; } = DateTime.Today;



        // Foreign Key Property  ~ Entity classes are easier to work with if you add Foreign Key properties that refer to the Primary Key in the related entity class
        [Required(ErrorMessage = "Please Enter a Customer")]
/*        [Remote(action: "CheckExistingAppointments", controller: "AppointmentValidation", AdditionalFields = "AppointmentDate")] */
        public int CustomerId { get; set; }

        // NAVIGATION PROPERTY
        // Calls in our Customer Class To be set to each Appointment   LINKS BOTH CLASSES TOGETHER
        [ValidateNever]
        public Customer Customer { get; set; } = null!;

    }
}
