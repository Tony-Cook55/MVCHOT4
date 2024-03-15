using Microsoft.EntityFrameworkCore;

namespace HOT4.Models
{
    public class AppointmentContext           :DbContext
    {

        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options)
        {
        }



        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer() { CustomerId = 1, Username = "JimmyFalcone", PhoneNumber = "314-123-1241" },
                new Customer() { CustomerId = 2, Username = "TreyPointer", PhoneNumber = "(314)612-1890" },
                new Customer() { CustomerId = 3, Username = "Mr.G", PhoneNumber = "(512)163-2783" }
            );



            modelBuilder.Entity<Appointment>().HasData(
                new Appointment()
                {
                    AppointmentId = 1,
                    AppointmentDate = new DateTime(2024, 3, 15, 8, 0, 0), // Year, month, day, hour, minute, second
                    CustomerId = 2
                }
            );

        }


    }
}
