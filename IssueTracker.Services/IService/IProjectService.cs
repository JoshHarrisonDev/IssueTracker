using IssueTracker.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssueTracker.Services.IService
{
    public interface IProjectService
    {
        IList<Project> GetProjects();

        Project GetProject(int id);

        void Add(Project project);

        void Update(Project project);   

        void Delete(Project project); 

      
    }
}
