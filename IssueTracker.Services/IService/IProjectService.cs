using IssueTracker.Data.Domain;

namespace IssueTracker.Services.IService
{
    public interface IProjectService
    {
        IList<Project> GetProjects();

        Project GetProject(int id);

        void Add(Project project);

        void Update(Project project);

        void Delete(Project project);

        Person GetProjectLead(int projectID);


    }
}
