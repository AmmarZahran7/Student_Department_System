using First_Task_Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace First_Task_Mvc.Context
{
    public class TaskDb:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= DESKTOP-JCL1G18\\SQLEXPRESS;Database=First_Mvc_task;Trusted_Connection=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
       
   
    }
}
