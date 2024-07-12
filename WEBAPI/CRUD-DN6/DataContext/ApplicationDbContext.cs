using CRUD_DN6.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUD_DN6.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<EmployeeModel> employees2 { get; set; }
    }
}
