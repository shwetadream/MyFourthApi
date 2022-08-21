using Microsoft.EntityFrameworkCore;

namespace MyFourthApi.Data
{
    public class JobDbContext:DbContext
    {
        public JobDbContext(DbContextOptions<JobDbContext> options)
            : base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Location> Locations { get; set; }

    }
    
}
