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
    }
}
