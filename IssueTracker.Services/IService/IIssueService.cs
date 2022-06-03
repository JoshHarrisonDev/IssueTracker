using IssueTracker.Data.Domain;

namespace IssueTracker.Services.IService
{
    public interface IIssueService
    {
        void Add(Issue issue, int personID);

        void Update(Issue issue);

        void Delete(Issue issue);

        IList<Issue> GetIssueForProject(int projectID);

        IList<Issue> GetAllIssues();
        Issue GetIssue(int issueID);

        IList<Issue> GetAssignedIssues(int personID);

        Issue GetAssignedIssue(int issueID, int personID);

        IList<Issue> GetUnassignedIssuesForProject(int projectID);

        void AssignIssueToPerson(int issueID, int personID);

    }
}
