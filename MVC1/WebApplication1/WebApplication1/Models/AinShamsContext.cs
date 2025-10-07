using Microsoft.EntityFrameworkCore;

namespace MVC1.Models
{
    public class AinShamsContext : DbContext
    {
        /*any class need to be converted into a table
         it must me set hfere
         * */
        //                    this is the table name  
        public DbSet<Employee> Employee { get; set; }

        /*if we stop here at this step:
         * it will go the employee clsaas and generate 
         * a table employees and see the department foreign key 
         * but there is no department in the db context itself 
         * so we must add it here 
         * and if we didn't set the department as a foreign key 
         * the dbset won't know taht there is department and it will be only emplyee
         */
        public DbSet<Department> Department { get; set; }
        public AinShamsContext():base()
        { 

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer
           ("Data Source=.;Initial Catalog=AinShamsDB;Integrated Security=True;Encrypt=False;" +
           "Trust Server Certificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
