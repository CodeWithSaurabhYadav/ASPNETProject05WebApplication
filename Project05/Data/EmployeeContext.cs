using Microsoft.EntityFrameworkCore;
using Project05.Models;

namespace Project05.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options) { }

        public DbSet<EmployeeModel> Employees { get; set; }
        public object Employee { get; internal set; }
    }
}
