using IssueTracker.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Issue> Issue { get; set; }

        public DbSet<Person> Person { get; set; }

        public DbSet<Project> Project { get; set; }
    }
}
