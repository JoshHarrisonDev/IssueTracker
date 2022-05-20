using IssueTracker.Models;
using IssueTracker.Services.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IssueTracker.Controllers
{
    public class RoleController : Controller
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<IdentityUser> _userManager;
        private IPersonService _personService;
        public RoleController(RoleManager<IdentityRole> roleManager, IPersonService personService, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _personService = personService;
            _userManager = userManager;
        }
        // GET: RoleController
        public ActionResult Index()
        {

            return View(_roleManager.Roles);
        }

        // GET: RoleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RoleController/Create
        public ActionResult Create()
        {


            return View();
        }
        public ActionResult AssignUserToRole()
        {
            RoleAssign roleAssign = new RoleAssign();
            roleAssign.Roles = _roleManager.Roles.ToList();
            roleAssign.RolelessPeople = _personService.GetRolelessPeople();

            return View(roleAssign);
        }

        [HttpPost]
        public async Task<IActionResult> AssignUserToRole(RoleAssign roleAssign)
        {
            var person = _personService.Get(roleAssign.UserID);
            _personService.AssignRole(roleAssign.RoleName, roleAssign.UserID);
            IdentityUser identityUser = await _userManager.FindByEmailAsync(person.Email);
            await _userManager.AddToRoleAsync(identityUser, roleAssign.RoleName);
            return RedirectToAction("Index");
        }

        // POST: RoleController/Create
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

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RoleController/Edit/5
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

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RoleController/Delete/5
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
