using Microsoft.EntityFrameworkCore;
using Sprout.Exam.DataAccess.Models;

namespace Sprout.Exam.DataAccess.Data
{
    public class EmployeeDbContext : DbContext
    {

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> employee { get; set; }

    }
}
