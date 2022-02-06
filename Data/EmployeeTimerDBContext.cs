using EmployeeTimeMonitor.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimeMonitor.Data
{
    public class EmployeeTimerDBContext : DbContext
    {
        public EmployeeTimerDBContext(DbContextOptions<EmployeeTimerDBContext> options)
           : base(options)
        {

        }

        public DbSet<Employee> EmployeeTimerRecord { get; set; }
    }
}
