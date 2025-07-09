using Microsoft.EntityFrameworkCore;
using MYFirstApi.Models;

namespace MYFirstApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
              
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
