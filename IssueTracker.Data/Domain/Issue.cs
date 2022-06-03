namespace IssueTracker.Data.Domain
{
    public class Issue
    {
        public int ID { get; set; }


        public string Summary { get; set; } = default!;

        public string Description { get; set; } = default!;

        public Person? IdentifiedBy { get; set; } = default!;

        public DateTime IdentifiedOn { get; set; } = DateTime.Now;

        public virtual Project Project { get; set; } = default!;
        public int ProjectID { get; set; } = default!;

        public StatusCode Status { get; set; } = default!;

        public PriorityLevels Priority { get; set; } = default!;

        public DateTime TargetResolutionDate { get; set; }

        public DateTime ActualResolutionDate { get; set; }

        public string? ResolutionSummary { get; set; }

        public DateTime CreatedAt { get; set; }

        public Person? CreatedBy { get; set; } = default!;

        public DateTime? ModifiedAt { get; set; }

        public Person? ModifiedBy { get; set; }

        public virtual Person? AssignedTo { get; set; }

        public string? Progress { get; set; }


        public enum PriorityLevels
        {
            Low = 0, Medium = 1, High = 2
        }

        public enum StatusCode
        {
            NotStarted = 0,
            InProgress = 1,
            Complete = 2,
        }
    }

}
