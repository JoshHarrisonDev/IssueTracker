using IssueTracker.Data.Domain;

namespace IssueTracker.Models
{
    public class ProjectIssuePersonModel
    {
        public int Id { get; set; }

        public string ProjectName { get; set; }

        public IList<Person> People { get; set; }

        public IList<Issue> Issues { get; set; }
        public Person ProjectLead { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime TargetEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }


    }
}
