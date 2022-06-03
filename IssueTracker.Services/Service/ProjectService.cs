using IssueTracker.Data;
using IssueTracker.Data.Domain;
using IssueTracker.Services.IService;

namespace IssueTracker.Services.Service
{
    public class ProjectService : IProjectService
    {
        private IssueTrackerContext _context;
        private IPersonService _personService;

        public ProjectService(IssueTrackerContext context, IPersonService personService)
        {
            _context = context;
            _personService = personService;
        }

        public void Add(Project project)
        {
            _context.Project.Add(project);
            _context.SaveChanges();
        }

        public void Delete(Project project)
        {
            _context.Project.Remove(project);
            _context.SaveChanges();
        }


        public Project GetProject(int ID)
        {
            IList<Project> projects = GetProjects();
#pragma warning disable CS8603 // Possible null reference return.
            return projects.FirstOrDefault(p => p.ID == ID);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public Person GetProjectLead(int projectID)
        {
            Project project = GetProject(projectID);
            Person projectLead = _personService.Get(project.ProjectLead);
            return projectLead;
        }

        public IList<Project> GetProjects()
        {
            return _context.Project.ToList();
        }

        public void Update(Project project)
        {
            Project projectToUpdate = GetProject(project.ID);
            _context.Update(projectToUpdate).CurrentValues.SetValues(project);
            _context.SaveChanges();
        }
    }
}
