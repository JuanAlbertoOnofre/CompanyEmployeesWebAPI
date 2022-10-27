using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

//Create the context class, which will be a middleware component for communication with the database
namespace Entities
{
   //It must inherit from the Entity Framework Core’s DbContext class and it consists of DbSet properties
    public class RepositoryContext: DbContext
    {
        //which EF Core is going to use for the communication with the database.
        //Install the Microsoft.EntityFrameworkCore
        //appsettings.json file and add the connection string named sqlconnection
        public RepositoryContext(DbContextOptions options) : base(options)
        { }

        //Invoke the configuration
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
        }
        //Add-Migration InitialData
        //Update-Database


        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
