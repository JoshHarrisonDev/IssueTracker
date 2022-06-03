using IssueTracker.Data;
using IssueTracker.Data.Domain;
using IssueTracker.Services.IService;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Services.Service
{
    public class IssueService : IIssueService
    {
        private IssueTrackerContext _context;
        private IProjectService _projectService;
        private IPersonService _personService;

        public IssueService(IssueTrackerContext context, IProjectService projectService, IPersonService personService)
        {
            _context = context;
            _projectService = projectService;
            _personService = personService;
        }

        public void Add(Issue issue, int personID)
        {
            issue.CreatedBy = _personService.Get(personID);
            issue.ModifiedBy = _personService.Get(personID);

            _context.Issue.Add(issue);
            _context.SaveChanges();
        }

        public void AssignIssueToPerson(int issueID, int personID)
        {
            Issue issue = GetIssue(issueID);
            Person person = _personService.Get(personID);
            issue.AssignedTo = person;

            _context.SaveChanges();
        }

        public void Delete(Issue issue)
        {
            _context.Issue.Remove(issue);
            _context.SaveChanges();
        }

        public IList<Issue> GetAllIssues()
        {
            return _context.Issue.Include(i => i.ProjectID).Include(i => i.IdentifiedBy).Include(i => i.ModifiedBy).Include(i => i.AssignedTo).Include(i => i.Project).Include(i => i.CreatedBy).ToList();


        }

        public Issue GetAssignedIssue(int issueID, int personID)
        {
            IList<Issue> issues = GetAssignedIssues(personID);
#pragma warning disable CS8603 // Possible null reference return.
            return issues.FirstOrDefault(i => i.ID == issueID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IList<Issue> GetAssignedIssues(int personID)
        {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return GetAllIssues().Where(i => i.AssignedTo.ID == personID).ToList();
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }

        public Issue GetIssue(int issueID)
        {
            IList<Issue> issues = GetAllIssues();
#pragma warning disable CS8603 // Possible null reference return.
            return issues.FirstOrDefault(i => i.ID == issueID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public IList<Issue> GetIssueForProject(int projectID)
        {
            return GetAllIssues().Where(i => i.ProjectID == projectID).ToList();
        }

        public IList<Issue> GetUnassignedIssuesForProject(int projectID)
        {
            return GetIssueForProject(projectID).Where(i => i.AssignedTo == null).ToList();
        }

        public void Update(Issue issue)
        {
            Issue issueToUpdate = GetIssue(issue.ID);
            _context.Issue.Update(issueToUpdate).CurrentValues.SetValues(issue);
            _context.SaveChanges();
        }
    }
}
