using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MBCFM.Models
{
    public class JobsContext : DbContext
    {
        public JobsContext()
            : base("JobsContext")
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<ExtraJobData> ExtraJobs { get; set; }
    }
}