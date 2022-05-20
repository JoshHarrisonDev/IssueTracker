using IssueTracker.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IssueTracker.Models;

namespace IssueTracker.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectService _projectService;
        private IPersonService _personService;
        private IIssueService _issueService;
        public ProjectController(IProjectService projectService, IPersonService personService, IIssueService issueService)
        {
            _projectService = projectService;
            _personService = personService;
            _issueService = issueService;

        }
        // GET: ProjectController
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult GetProject(int userId)
        {
            var person = _personService.Get(userId);
            ProjectIssuePersonModel model = new ProjectIssuePersonModel()
            {
                Id = (int)person.ProjectID,
                Issues = _issueService.GetIssueForProject((int)person.ProjectID),
                People = _personService.GetPersonsWithProject((int)person.ProjectID),
                CreatedAt = _projectService.GetProject((int)person.ProjectID).CreatedAt,
                ModifiedAt = _projectService.GetProject((int)person.ProjectID).ModifiedAt,
                ActualEndDate = _projectService.GetProject((int)person.ProjectID).ActualEndDate,
                ProjectLead = _projectService.GetProjectLead((int)person.ProjectID),
                ProjectName = _projectService.GetProject((int)person.ProjectID).ProjectName,
                StartDate = _projectService.GetProject((int)person.ProjectID).StartDate,
                TargetEndDate = _projectService.GetProject((int)person.ProjectID).TargetEndDate,
            };
           
            return View(model);
        }

        // GET: ProjectController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProjectController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProjectController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProjectController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProjectController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProjectController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
