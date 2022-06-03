namespace IssueTracker.Data.Domain
{
    public class Project
    {
        public int ID { get; set; }

        public string ProjectName { get; set; } = default!;


        public DateTime StartDate { get; set; }

        public DateTime TargetEndDate { get; set; }
        public DateTime ActualEndDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int ModifiedByPerson { get; set; }

        public int ProjectLead { get; set; } = default!;


    }
}
