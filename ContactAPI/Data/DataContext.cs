using Microsoft.EntityFrameworkCore;
using ContactAPI.Models;

namespace ContactAPI.Data
{
    public class DataContext:DbContext
        //dbcontext refers a session with database
        
    {
        //we have to use DbContextOptions as param in this constructor and inherit from base options
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {
            
        }
        // we created a table with assosciation to contact called Contacts
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    Id = 1,
                    FirstName = "Pavan",
                    LastName = "manikanta",
                    Phone = 9951658045,
                    City = "Sap",
                    CreatedDate = DateTime.Now
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "Harini",
                    LastName = "Devathi",
                    Phone = 9381272144,
                    City = "GNT",
                    CreatedDate = DateTime.Now
                }
                );
        }
    }
}
